using HiringPortalAPI.Application.Interfaces;
using HiringPortalAPI.Application.ViewModels;
using HiringPortalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiringPortalAPI.Application.Services
{
    public class UpdateShortlistStatusService:IUpdateShortlistStatus
    {
        private ICandidateRepository _candidateRepository;

        public UpdateShortlistStatusService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public UpdateShortlistSatusViewModel UpdateShortlistStatus()
        {
            return new UpdateShortlistSatusViewModel
            {
                UpdateShortlistStatus = _candidateRepository.UpdateShortlistStatus()
        };

        
    }
    }
}
