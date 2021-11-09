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
        private readonly WhatToWearService _whatToWearService;

        public WhatToWearController(ILogger<WhatToWearController> logger, WhatToWearService w) : base(logger)
        {           
            _whatToWearService = w;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return await ExecuteActionAsync(() =>
            {
                return _whatToWearService.GetClothesOrderByWeatherAsync(id);
            });
        }
    }
}
