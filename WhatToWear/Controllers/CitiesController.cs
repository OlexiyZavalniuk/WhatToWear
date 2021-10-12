using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhatToWear.Models.Models;
using WhatToWear.Core;

namespace WhatToWear.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class citiesController : ControllerBase
    {

        private readonly ILogger<citiesController> _logger;

        public citiesController(ILogger<citiesController> logger)
        {
            _logger = logger;
        }

        [Route("{name}")]
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await CityService.GetCitiesAsync(name));
        }
    }
}
