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
    public class WhatToWearController : ActionController<WhatToWearController>
    {
        private readonly WhatToWearService _whatToWearService;

        private readonly ILogger<WhatToWearController> _logger;

        public WhatToWearController(ILogger<WhatToWearController> logger, WhatToWearService w) : base(logger)
        {           
            _logger = logger;
            _whatToWearService = w;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return await ExecuteActionAsync(() =>
            {
                return _whatToWearService.GetClothesOrderByWeather(id);
            });
        }
    }
}
