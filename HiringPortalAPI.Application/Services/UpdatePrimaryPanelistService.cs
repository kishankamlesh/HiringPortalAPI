using HiringPortalAPI.Application.Interfaces;
using HiringPortalAPI.Application.ViewModels;
using HiringPortalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HiringPortalAPI.Application.Services
{
    public class UpdatePrimaryPanelistService : IUpdatePrimaryPanelist
    {
        private ICandidateRepository _candidateRepository;

        public UpdatePrimaryPanelistService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public UpdatePrimaryPanelistViewModel UpdatePanelist()
        {
            return new UpdatePrimaryPanelistViewModel()
            {
                UpdatedPanelist = _candidateRepository.UpdatePanelist()
            };
        }

        
    }
}
