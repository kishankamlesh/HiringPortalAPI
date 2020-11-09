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
    public class UpdatePrimaryPanelistController : ControllerBase
    {
        private IUpdatePrimaryPanelist _updatePanelist;

        public UpdatePrimaryPanelistController(IUpdatePrimaryPanelist updatePanelist)
        {
            _updatePanelist = updatePanelist;
        }

        public IActionResult UpdatePanelist()
        {

            return Ok(_updatePanelist.UpdatePanelist());
        }
    }
}
