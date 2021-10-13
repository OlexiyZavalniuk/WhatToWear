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
        private CityService _cityService;

        private readonly ILogger<citiesController> _logger;

        public citiesController(ILogger<citiesController> logger, CityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        [Route("{name}")]
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _cityService.GetCitiesAsync(name));
        }
    }
}
