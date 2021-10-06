using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<City> Get(string name)
        {
            return CityService.GetCities(name);
        }
    }
}
