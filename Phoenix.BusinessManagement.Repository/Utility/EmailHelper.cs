using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Phoenix.BusinessManagement.Repository.Utility
{
    public static class EmailHelper
    {
        
        public static async void SendMail(string toMail, string mailSubject, string mailMessage)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            string fromMailName = configuration.GetSection("EmailConfig:FromMailName").Value.ToString();
            string fromMail = configuration.GetSection("EmailConfig:FromMail").Value.ToString();
            string fromMailPassword = configuration.GetSection("EmailConfig:FromMailPassword").Value.ToString();
            string host = configuration.GetSection("EmailConfig:Host").Value.ToString();
            int port = Convert.ToInt32(configuration.GetSection("EmailConfig:Port").Value.ToString());
            bool IsUseSSL = Convert.ToBoolean(configuration.GetSection("EmailConfig:IsUseSSL").Value.ToString());

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(fromMail);
            message.To.Add(new MailAddress(toMail));
            message.Subject = mailSubject;
            message.IsBodyHtml = true; //to make message body as html
            message.Body = mailMessage;
            smtp.Port = port;
            smtp.Host = host;
            smtp.EnableSsl = IsUseSSL;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail, fromMailPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);
        }
        
    }
}
