using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WhatToWear.Core;

namespace WhatToWear.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeatingController : ActionController<HeatingController>
    {
        private readonly IHeatingCalculationService _heatingCalculationService;

        public HeatingController(ILogger<HeatingController> logger, IHeatingCalculationService h) : base(logger)
        {
            _heatingCalculationService = h;
        }

        [Route("{id}-{temp}-{square}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id, double temp, double square)
        {
            return await ExecuteActionAsync(() =>
            {
                return _heatingCalculationService.CalculateAsync(id, temp, square);
            });
        }
    }
}
