using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration config;

        public EmailSender(IConfiguration config)
        {
            this.config = config;
        }
        public void SendEmail(string To, string Title, string Message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(config["MailSettings:From"]));
            email.To.Add(MailboxAddress.Parse(To));
            email.Subject = Title;

            var builder = new BodyBuilder
            {
                HtmlBody = Message
            };

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            try
            {
                smtp.Connect(config["MailSettings:Host"], int.Parse(config["MailSettings:Port"]), SecureSocketOptions.StartTls);
                smtp.Authenticate(config["MailSettings:From"], config["MailSettings:Password"]);
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                smtp.Disconnect(true);
            }
        }
    }
    
}
