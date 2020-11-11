using HiringPortalAPI.Domain.Interfaces;
using HiringPortalAPI.Domain.Models;
using Microsoft.Identity.Client;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;


namespace HiringPortalAPI.Infra.Data.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        public static AuthenticationManager authManager = new AuthenticationManager();


        private static Task<AuthenticationResult> _result = GetAccessToken();
        ClientContext ctx = authManager.GetAzureADAccessTokenAuthenticatedContext("https://gearedupteam.sharepoint.com/sites/GearedUpSite", _result.Result.AccessToken);
        private static async Task<AuthenticationResult> GetAccessToken()
        {
            var ClientId = "59f6f9ba-c753-4b75-8758-5f98b469fd92";
            var Tenant = "954b4cce-757c-4cf3-bed1-c57d4630bf74";
            var spAccountSecret = "Deloitte.123";
            var SpAccount = "interns@gearedupteam.onmicrosoft.com";

            IPublicClientApplication app;

            app = PublicClientApplicationBuilder.Create(ClientId).WithTenantId(Tenant).Build();

            string[] scopes = new string[] { "https://gearedupteam.sharepoint.com/.default" };

            AuthenticationResult result = null;

            SecureString s = new SecureString();
            foreach (char c in spAccountSecret)
                s.AppendChar(c);
            try
            {
                result = await app.AcquireTokenByUsernamePassword(scopes, SpAccount, s).ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            return result;
        }

        public List<HiringInfoModel> GetCandidates()
        {
            var oList = ctx.Web.Lists.GetByTitle("GDAS-Hiring-Info");
            
            

            var camlQuery = new CamlQuery
            {
                ViewXml = "<View><Query><Where><Geq><FieldRef Name='ID'/>" +
                "<Value Type='Number'>0</Value></Geq></Where></Query><RowLimit>100</RowLimit></View>"
            };

            var collListItem = oList.GetItems(camlQuery);
            ctx.Load(collListItem);
            ctx.ExecuteQuery();
            

            var hiringInfoList = (from ListItem oListItem in collListItem

                                  let primaryPanelistData = (FieldUserValue)oListItem["UsedForScreeningPrimaryPanelist"]
                                  let panelistEmail = primaryPanelistData != null ? Convert.ToString(primaryPanelistData.Email) : null
                                  let delegatedPanelistData = (FieldUserValue)oListItem["DelegatedPanelist"]
                                  let delegatedPanelistEmail = delegatedPanelistData != null ? Convert.ToString(delegatedPanelistData.Email) : null
                                  let lookupCandidateIdData = (FieldLookupValue) oListItem["Candidate_Id"]
                                  let lookupCandidateId = lookupCandidateIdData != null ? (lookupCandidateIdData.LookupValue) : null
                                  let lookupCandidateNameData = (FieldLookupValue)oListItem["Candidate_Id_x003a_Candidate_x00"]
                                  let lookupCandidateName = lookupCandidateNameData != null ? Convert.ToString(lookupCandidateNameData.LookupValue) : null
                                  //let studioTeamData = (FieldUserValue)oListItem["StudioTeam_x002f_HiringPanel"]
                                  //let studioTeamEmail = studioTeamData.Email != null? studioTeamData.Email.ToString() : null

                                  select new HiringInfoModel
                                  {
                                      Title = oListItem["Title"] != null ? oListItem["Title"].ToString() : null,
                                      CandidateID = oListItem["CandidateID"] != null ? oListItem["CandidateID"].ToString() : null,
                                      CandidateName = oListItem["CandidateName"] != null ? oListItem["CandidateName"].ToString() : null,
                                      CandidateShortlisted = oListItem["candidateshortlisted"] != null ? oListItem["candidateshortlisted"].ToString() : null,
                                      CandidateEmailID = oListItem["CandidateEmailID"] != null ? oListItem["CandidateEmailID"].ToString() : null,
                                      CandidateContactNumber = oListItem["CandidateContactNumber"] != null ? oListItem["CandidateContactNumber"].ToString() : null,
                                      PrimaryPanelist = panelistEmail,
                                      DelegatedPanelist = delegatedPanelistEmail,
                                      HRPersonOrGroupInterviewStatus = oListItem["HRPersonOrGroupInterviewStatus"] != null ? oListItem["HRPersonOrGroupInterviewStatus"].ToString() : null,
                                      InterviewLevel = oListItem["InterviewLevel"] != null ? oListItem["InterviewLevel"].ToString() : null,
                                      //StudioTeam = studioTeamEmail,
                                      lookupCandidateId = (lookupCandidateId).Substring(0,4),
                                      lookupCandidateName = lookupCandidateName
                                  }).ToList();
            
            return (hiringInfoList);
        }
        public List<string> GetPanelistData()
        {
            List<string> panelistData = new List<string>();
            var groupCollection = ctx.Web.SiteGroups;
            var getGroup = groupCollection.GetByName("Panelists");
            var collUser = getGroup.Users;
            ctx.Load(collUser);
            ctx.ExecuteQuery();

            foreach (var getUser in collUser)
            {
                panelistData.Add(getUser.Title.ToString());
                panelistData.Add(getUser.Email.ToString());
                panelistData.Add(getUser.LoginName.ToString());
                
            }
            
            return panelistData;
            
        }

        public bool UpdatePanelist()
        {
            bool updateStatus = false;
            string id = "1023";
            string email = "Panelist1@gearedupteam.onmicrosoft.com";


            var oList = ctx.Web.Lists.GetByTitle("GDAS-Hiring-Info");
            var camlQuery = new CamlQuery
            {
                ViewXml = "<View><Query><Where><Eq><FieldRef Name='CandidateID'/>" +
                "<Value Type='Number'>"+id+"</Value></Eq></Where></Query><RowLimit>100</RowLimit></View>"
            };
            try
            {
                //getting the particular candidate using caml query
                var collListItem = oList.GetItems(camlQuery);
                ctx.Load(collListItem);
                ctx.ExecuteQuery();

                //getting users
                var users = ctx.Web.SiteUsers;
                ctx.Load(users);
                ctx.ExecuteQuery();


                //getting panlists data
                var panelist = users.GetByEmail(email);
                ctx.Load(panelist);
                ctx.ExecuteQuery();
                var assignedToValue = new FieldUserValue() { LookupId = panelist.Id };
                var assignedToValues = new[] { assignedToValue };

                //updating data
                foreach (var listItem in collListItem)
                {
                    listItem["UsedForScreeningPrimaryPanelist"] = assignedToValues;
                    listItem["candidateshortlisted"] = "1";
                    listItem.Update();
                }
                ctx.ExecuteQuery();
                updateStatus = true;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Occured: " + ex.Message.ToString());
            }                                                                       
            return updateStatus;
        }
    }
}
