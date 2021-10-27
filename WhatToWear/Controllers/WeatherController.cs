using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToWear.Core;
using WhatToWear.Models.DTO;

namespace WhatToWear.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private GetWeatherService _weatherService;

        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger, GetWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<double> Get(int id)
        {
            return Ok(_weatherService.GetWeather(id).Main.Feels_like);
        }
    }
}
