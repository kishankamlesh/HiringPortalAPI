using HiringPortalAPI.Application.Interfaces;
using HiringPortalAPI.Application.ViewModels;
using HiringPortalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiringPortalAPI.Application.Services
{
    public class GetPanelistDataService: IGetPanelistData
    {
        private ICandidateRepository _candidateRepository;

        public GetPanelistDataService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public GetPanelistDataViewModel GetPanelistData()
        {
            return new GetPanelistDataViewModel()
            {
                PanelistInfo = _candidateRepository.GetPanelistData()
            };
        }
    }
}
