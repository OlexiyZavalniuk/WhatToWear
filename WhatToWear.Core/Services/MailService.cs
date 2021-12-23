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
using System.Net;
using System.Text;

namespace WhatToWear.Core
{
    public class MailService : IMailService
    {
        private readonly string _apiPath;

        private readonly ApplicationContext _db;

        private readonly IWhatToWearService _whatToWearService;

        private readonly HttpClient _client;

        private readonly MailSettingsDTO _mailSettings;

        public MailService(ApplicationContext appContext, IWhatToWearService whatToWearService, HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _db = appContext;
            _whatToWearService = whatToWearService;
            _apiPath = configuration.GetConnectionString("NameDayAPI");
            _mailSettings = new()
            {
                Mail = configuration.GetConnectionString("Mail"),
                Password = configuration.GetConnectionString("Password"),
                Host = configuration.GetConnectionString("Host"),
                Port = Convert.ToInt32(configuration.GetConnectionString("Port"))
            };
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

            StringBuilder message = new();
            foreach(var c in clothes.Clothes)
            {
                message.AppendLine($"{c.Name} ({c.Temperature} °C)");
            }
            message.Append($" Weather: {clothes.Weather.Description} ({clothes.Weather.Temperature} °C)");
            string subject = "Hello, " + user.Name + "! Clothes for today:";

            RecurringJob.AddOrUpdate(Convert.ToString(id), () => SendAsync(user.Link, subject, message.ToString(), name), Cron.Daily(h, m), TimeZoneInfo.Local);    
        }

        public async Task SendAsync(string email, string subject, string message, string name)
        {
            var from = _mailSettings.Mail;
            var pass = _mailSettings.Password;
            var client = new SmtpClient(_mailSettings.Host, _mailSettings.Port)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, pass),
                EnableSsl = true
            };

            var mail = new MailMessage(from, email)
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            DrawService.DrawImage(name);

            var a = new Attachment("../WhatToWear.Database/Data/Result.jpg");

            mail.Attachments.Add(a);

            await client.SendMailAsync(mail);

            a.Dispose();
        }
    }
}
