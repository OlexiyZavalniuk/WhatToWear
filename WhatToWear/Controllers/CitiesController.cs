using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WhatToWear.Core;

namespace WhatToWear.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ActionController<CitiesController>
    {
        private readonly CityService _cityService;

        public CitiesController(ILogger<CitiesController> logger, CityService cityService) : base(logger)
        {
            _cityService = cityService;
        }

        [Route("{name}")]
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            return await ExecuteActionAsync(() =>
            {
                return _cityService.GetCitiesAsync(name);
            });
        }
    }
}
