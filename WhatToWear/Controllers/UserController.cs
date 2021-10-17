using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatToWear.Core;
using WhatToWear.Models.Models;

namespace WhatToWear.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] string name)
        {
            return Ok(await _userService.CreateUserAsync(name));
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<User>> Get(int id)
        {
            return Ok(await _userService.GetUserAsync(id));
        }

        [Route("")]
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [Route("")]
        [HttpPut]
        public async Task<ActionResult<User>> Update([FromBody] User user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok(await _userService.GetUserAsync(user.Id));
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
