using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiringPortalAPI.Application.Interfaces;

namespace HiringPortalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class UpdateShortlistStatusController : ControllerBase
    {
        private IUpdateShortlistStatus _updateShortlistStatus;
        public UpdateShortlistStatusController(IUpdateShortlistStatus updateShortlistStatus)
        {
            _updateShortlistStatus = updateShortlistStatus;
        }
        
        public IActionResult UpdateShortlistStatus()
        {
            return Ok(_updateShortlistStatus.UpdateShortlistStatus());
        }
    }
}
