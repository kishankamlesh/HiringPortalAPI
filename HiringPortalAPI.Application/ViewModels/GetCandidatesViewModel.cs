using HiringPortalAPI.Domain.Models;
using System.Collections.Generic;

namespace HiringPortalAPI.Application.ViewModels
{
    public class GetCandidatesViewModel
    {
        public List<HiringInfoModel> Candidates { get; set; }
    }
}
