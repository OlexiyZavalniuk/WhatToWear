using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WhatToWear.Core;
using WhatToWear.Models.DTO;

namespace WhatToWear.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ActionController<UserController>
    {
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService userService) : base(logger)
        {
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
            return await ExecuteActionAsync(() =>
            {
                return _userService.UpdateUserAsync(user);
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
