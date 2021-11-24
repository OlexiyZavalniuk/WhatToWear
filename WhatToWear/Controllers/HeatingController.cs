 using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToWear.Core;

namespace WhatToWear.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeatingController : ActionController<HeatingController>
    {
        private readonly HeatingCalculationService _heatingCalculationService;

        public HeatingController(ILogger<HeatingController> logger, HeatingCalculationService h) : base(logger)
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
