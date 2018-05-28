using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Services.Abstractions;

namespace WebApplication1.Services
{
    public class SmtpMailClient : IMailClient
    {
        /// <summary>
        /// Sends the email 
        /// </summary>
        /// <param name="receiverAddress">Email address of receiver</param>
        /// <param name="subject">The email subject</param>
        /// <param name="body">The email message</param>
        /// <returns>Status of sent email</returns>
        public bool SendEmail(string receiverAddress, string subject, string body)
        {
            bool isSuccessful = true;
            try
            {
                var message = new MailMessage();
                message.To.Add(receiverAddress);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Send(message);
                }
            }
            catch (Exception exception)
            {
                isSuccessful = false;
            }
            return isSuccessful;
        }

        /// <summary>
        /// Sends the email async
        /// </summary>
        /// <param name="receiverAddress">Email address of receiver</param>
        /// <param name="subject">The email subject</param>
        /// <param name="body">The email message</param>
        /// <returns>Status of sent email</returns>
        public async Task<bool> SendEmailAsync(string receiverAddress, string subject, string body)
        {
            return await Task.Run(() => SendEmail(receiverAddress, subject, body));
        }
    }
}