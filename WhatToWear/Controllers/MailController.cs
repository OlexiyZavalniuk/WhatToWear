using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Hangfire;
using WhatToWear.Core;
using Microsoft.Extensions.Logging;

namespace WhatToWear.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailController : ActionController<MailController>
    {
        private readonly IMailService _mailService;

        public MailController(ILogger<MailController> logger, IMailService mailService) : base(logger)
        {
            _mailService = mailService;
        }

        [Route("{id}&{h}-{m}")]
        [HttpGet]
        public async Task<IActionResult> GetAsync(int id, int h, int m)
        {
            return await ExecuteActionWithoutResultAsync(() =>
            {
                return _mailService.SendMailAsync(id, h, m);
            });
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            RecurringJob.RemoveIfExists(Convert.ToString(id));
            return Ok();
        }
    }
}
