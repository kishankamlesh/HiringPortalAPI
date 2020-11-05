using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiringPortalAPI.Application.Interfaces;
using HiringPortalAPI.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HiringPortalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HiringInfoController : Controller
    {
        private IGetCandidates _getCandidates;

        public HiringInfoController(IGetCandidates getCandidates)
        {
            _getCandidates = getCandidates;
        }

        public IActionResult ViewCandidates()
        {
            GetCandidatesViewModel model = _getCandidates.GetCandidates();
            return View(model);
        }
    }
}
