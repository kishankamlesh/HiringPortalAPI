using HiringPortalAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringPortalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class GetPanelistsByStringController : ControllerBase
    {
        private IGetPanelistsBySearchString _getPanelistsBySearchString;
        public GetPanelistsByStringController(IGetPanelistsBySearchString getPanelistsBySearchString)
        {
            _getPanelistsBySearchString = getPanelistsBySearchString;
        }
        [HttpGet("{searchQuery}")]
        public IActionResult GetPanelistsBySearchString(string searchQuery)
        {
            return Ok(_getPanelistsBySearchString.GetPanelistsBySearchString(searchQuery));
        }
    }
}
