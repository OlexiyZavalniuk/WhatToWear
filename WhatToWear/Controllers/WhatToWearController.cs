using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WhatToWear.Core;

namespace WhatToWear.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhatToWearController : ActionController<WhatToWearController>
    {
        private readonly IWhatToWearService _whatToWearService;

        public WhatToWearController(ILogger<WhatToWearController> logger, IWhatToWearService w) : base(logger)
        {           
            _whatToWearService = w;
        }

 
        [HttpGet("/now/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await ExecuteActionAsync(() =>
            {
                return _whatToWearService.GetClothesOrderByWeatherAsync(id);
            });
        }

        [HttpGet("/16days/{id}")]
        public async Task<IActionResult> Get16(int id)
        {
            return await ExecuteActionAsync(() =>
            {
                return _whatToWearService.GetClothesOrderByWeather16DaysAsync(id);
            });
        }

        [HttpGet("/trip/{id}-{city}")]
        public async Task<IActionResult> GetTrip(int id, double city)
        {
            return await ExecuteActionAsync(() =>
            {
                return _whatToWearService.GetClothesOrderByWeatherForTrip(id, city);
            });
        }

    }
}
