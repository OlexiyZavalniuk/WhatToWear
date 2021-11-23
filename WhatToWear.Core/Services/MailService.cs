using Hangfire;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WhatToWear.Database;
using WhatToWear.Models.Models;
using WhatToWear.Models.DTO;
using Newtonsoft.Json;
using System.Net.Mail;
using System.IO;

namespace WhatToWear.Core
{
    public class MailService
    {
        private readonly string _apiPath;

        private readonly ApplicationContext _db;

        private readonly WhatToWearService _whatToWearService;

        private readonly HttpClient _client;

        private readonly DrawService _drawService;

        public MailService(ApplicationContext appContext, WhatToWearService whatToWearService, HttpClient client, IConfiguration configuration, DrawService drawService)
        {
            _client = client;
            _db = appContext;
            _whatToWearService = whatToWearService;
            _apiPath = configuration.GetConnectionString("NameDayAPI");
            _drawService = drawService;
        }

        public async Task SendMailAsync(int id, int h, int m)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == default(User))
            {
                throw new Exception();
            }

            var clothes = await _whatToWearService.GetClothesOrderByWeatherAsync(id);

            var response = await _client.PostAsync(_apiPath, null);
            var obj = JsonConvert.DeserializeObject<NameDayDTO>(await response.Content.ReadAsStringAsync());
            var name = obj.Data.Namedays.Us.Split(",")[0];

            string message = "";
            foreach(var c in clothes)
            {
                message += c.Name + " (" + c.Temperature + " °C)" + Environment.NewLine;
            }
            string subject = "Hello, " + user.Name + "! Clothes for today:";

            RecurringJob.AddOrUpdate(Convert.ToString(id), () => SendAsync(user.Link, subject, message, name), Cron.Daily(h, m), TimeZoneInfo.Local);    
        }

        public Task SendAsync(string email, string subject, string message, string name)
        {
            var from = "whattowearsender@gmail.com";
            var pass = "15041865";
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(from, pass),
                EnableSsl = true
            };

            var mail = new MailMessage(from, email)
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            _drawService.DrawImage(name);

            mail.Attachments.Add(new Attachment("../WhatToWear.Database/Data/Result.jpg"));

            return client.SendMailAsync(mail);
        }
    }
}
