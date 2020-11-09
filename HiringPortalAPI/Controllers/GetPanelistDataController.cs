using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiringPortalAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiringPortalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GetPanelistDataController : ControllerBase
    {
        private IGetPanelistData _getPanelistData;

        public GetPanelistDataController(IGetPanelistData getPanelistData)
        {
            _getPanelistData = getPanelistData;
        }
        public IActionResult GetPanelistData()
        {
            return Ok(_getPanelistData.GetPanelistData());
        }
    }
}
