using HiringPortalAPI.Application.Interfaces;
using HiringPortalAPI.Application.ViewModels;
using HiringPortalAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace HiringPortalAPI.Application.Services
{
    public class GetCandidatesService : IGetCandidates
    {
        private ICandidateRepository _candidateRepository;

        public GetCandidatesService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public GetCandidatesViewModel GetCandidates()
        {
            return new GetCandidatesViewModel()
            {
                Candidates = _candidateRepository.GetCandidates()
            };
        }
    }
}
