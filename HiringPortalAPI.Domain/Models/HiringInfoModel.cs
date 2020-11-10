using System;
using System.Collections.Generic;
using System.Text;

namespace HiringPortalAPI.Domain.Models
{
    public class HiringInfoModel
    {
        public string Title { get; set; }
        public string CandidateID { get; set; }
        public string CandidateName { get; set; }
        public string CandidateEmailID { get; set; }
        public string CandidateContactNumber { get; set; }
        public string CandidateShortlisted { get; set; }
        public string UsedForScreeningPrimaryPanelist { get; set; }
        public string DelegatedPanelist { get; set; }
        public string StudioTeam { get; set; }
        public string InterviewLevel { get; set; }
        public string HRPersonOrGroupInterviewStatus { get; set; }
    }
}
