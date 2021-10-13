using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToWear.Core;

namespace WhatToWear.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class userController : ControllerBase
    {
        private UserService _userService;

        private readonly ILogger<userController> _logger;

        public userController(ILogger<userController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] string name)
        {
            return Ok(await _userService.CreateUserAsync(name));
        }
    }
}
