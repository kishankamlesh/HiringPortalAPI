using HiringPortalAPI.Application.Interfaces;
using HiringPortalAPI.Application.Services;
using HiringPortalAPI.Domain.Interfaces;
using HiringPortalAPI.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HiringPortalAPI.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<IGetCandidates, GetCandidatesService>();
            services.AddScoped<IUpdatePrimaryPanelist, UpdatePrimaryPanelistService>();
            services.AddScoped<IGetPanelistData, GetPanelistDataService>();
            services.AddScoped<IUpdateShortlistStatus, UpdateShortlistStatusService>();

            //infra.Data layer
            services.AddScoped<ICandidateRepository, CandidateRepository>();

        }
    }
}
