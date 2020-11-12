using HiringPortalAPI.Application.Interfaces;
using HiringPortalAPI.Application.ViewModels;
using HiringPortalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiringPortalAPI.Application.Services
{
    public class GetPanelistsBySearchStringService : IGetPanelistsBySearchString
    {
        private ICandidateRepository _candidateRepository;

        public GetPanelistsBySearchStringService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public GetPanelistsBySearchStringViewModel GetPanelistsBySearchString(string searchQuery)
        {
            return new GetPanelistsBySearchStringViewModel()
            {
                ReqPanelists = _candidateRepository.GetPanelistsBySearchString(searchQuery)
            };
        }
    }
}
