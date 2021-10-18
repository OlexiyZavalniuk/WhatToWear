using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToWear.Core;
using WhatToWear.Models.DTO;
using WhatToWear.Models.Models;

namespace WhatToWear.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClothesController : ControllerBase
    {
        private ClothesService _clothesService;

        private readonly ILogger<ClothesController> _logger;

        public ClothesController(ILogger<ClothesController> logger, ClothesService clothesService)
        {
            _logger = logger;
            _clothesService = clothesService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddClothes([FromBody] ClothesDTO clothes)
        {
            await _clothesService.AddClothesAsync(clothes);
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveClothes(int id)
        {
            await _clothesService.RemoveClothesAsync(id);
            return Ok();
        }
    }
}
