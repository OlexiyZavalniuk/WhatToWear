using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToWear.Core;
using WhatToWear.Models.DTO;
using WhatToWear.Models.Models;

namespace WhatToWear.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClothesController : ActionController<ClothesController>
    {
        private ClothesService _clothesService;

        private readonly ILogger<ClothesController> _logger;

        public ClothesController(ILogger<ClothesController> logger, ClothesService clothesService) : base(logger)
        {
            _logger = logger;
            _clothesService = clothesService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddClothes([FromBody] InClothesDTO clothes)
        {
            return await ExecuteActionWithoutResultAsync(() =>
            {
                return _clothesService.AddClothesAsync(clothes);
            });
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveClothes(int id)
        {
            return await ExecuteActionWithoutResultAsync(() =>
            {
                return _clothesService.RemoveClothesAsync(id);
            });
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetClothes(int id)
        {
            return await ExecuteActionAsync(() =>
            {
                return  _clothesService.GetClothesAsync(id);
            });
        }
    }
}
