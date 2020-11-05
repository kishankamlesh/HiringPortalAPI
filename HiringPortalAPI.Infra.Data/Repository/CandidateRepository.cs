using HiringPortalAPI.Domain.Interfaces;
using HiringPortalAPI.Domain.Models;
using Microsoft.Identity.Client;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HiringPortalAPI.Infra.Data.Repository
{
    public class CandidateRepository : ICandidateRepository
    {
        public static AuthenticationManager authManager = new AuthenticationManager();


        private static Task<AuthenticationResult>  _result = GetAccessToken();
        ClientContext ctx = authManager.GetAzureADAccessTokenAuthenticatedContext("https://gearedupteam.sharepoint.com/sites/GearedUpSite", _result.AccessToken);
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
            return result;
        }
        
        public List<HiringInfoModel> GetCandidates()
        {
            throw new NotImplementedException();
        }

    }
}
