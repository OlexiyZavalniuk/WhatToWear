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
    public class WeatherController : ActionController<WeatherController>
    {
        private GetWeatherService _weatherService;

        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger, GetWeatherService weatherService) : base(logger)
        {           
            _logger = logger;
            _weatherService = weatherService;
        }

        //[Route("{id}")]
        //[HttpGet]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return await ExecuteActionAsync(() =>
        //    {
        //        var result = _weatherService.GetWeather(id).Result.Main.Feels_like;
        //        return result;
        //    });
        //}
    }
}
