using Hangfire;
using System;
using System.Linq;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.Models;

namespace WhatToWear.Core
{
    public class MailService
    {
        private readonly ApplicationContext _db;

        private readonly WhatToWearService _whatToWearService;

        public MailService(ApplicationContext appContext, WhatToWearService whatToWearService)
        {
            _db = appContext;
            _whatToWearService = whatToWearService;
        }

        public async Task SendMailsAsync(int id, int h, int m)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == default(User))
            {
                throw new Exception();
            }

            var clothes = await _whatToWearService.GetClothesOrderByWeatherAsync(id);

            string message = "";
            foreach(var c in clothes)
            {
                message += c.Name + " (" + c.Temperature + " °C)" + Environment.NewLine;
            }
            string subject = "Hello, " + user.Name + "! Clothes for today:";

            RecurringJob.AddOrUpdate(Convert.ToString(id), () => MailSender.SendEmailAsync(user.Link, subject, message), Cron.Daily(h, m), TimeZoneInfo.Local);    
        }

    }
}
