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
    public class UserController : ActionController<UserController>
    {
        private UserService _userService;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, UserService userService) : base(logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string name)
        {
            return await ExecuteActionAsync(() =>
            {
                return _userService.CreateUserAsync(name);
            });
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {

            return await ExecuteActionAsync(() =>
            {
                return _userService.GetUserAsync(id);
            });
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await ExecuteActionAsync(() =>
            {
                return _userService.GetUsersAsync();
            });
        }

        [Route("")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDTO user)
        {
            await ExecuteActionWithoutResultAsync(() =>
            {
                return _userService.UpdateUserAsync(user);
            });
            return await ExecuteActionAsync(() =>
            {
                return _userService.GetUserAsync(user.Id);
            });
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return await ExecuteActionWithoutResultAsync(() =>
            {
                return _userService.DeleteUserAsync(id);

            });
        }
    }
}
