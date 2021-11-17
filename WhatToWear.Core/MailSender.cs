using System.Net.Mail;
using System.Threading.Tasks;

namespace WhatToWear.Core
{
    public static class MailSender
    {
        public static Task SendEmailAsync(string email, string subject, string message)
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
            return client.SendMailAsync(mail);
        }
    }
}
