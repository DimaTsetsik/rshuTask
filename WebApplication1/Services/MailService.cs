using System;
using System.IO;
using System.Web;
using System.Configuration;
using RazorEngine;
using System.Threading.Tasks;
using WebApplication1.Services.Abstractions;
using RazorEngine.Templating;

namespace WebApplication1.Services
{
    /// <summary>
    /// Represents service for working with mail
    /// </summary>
    public class MailService : IMailService
    {
        protected readonly IMailClient mailClient;
        private readonly string contactMessagePath = "~/Views/Mail/ContactMessage.cshtml";

        public MailService(IMailClient ImailClient)
        {
            mailClient = ImailClient;
        }

        public async Task<bool> SendMessage(string userEmail, string userName, string message)
        {
            var result = false;

            try
            {
                var model = new
                {
                    UserEmail = userEmail,
                    UserMessage = message,
                    UserName = userName
                };

                var serverPath = HttpContext.Current.Server.MapPath(contactMessagePath);
                var template = File.ReadAllText(serverPath);
                var body = Engine.Razor.RunCompile(template, DateTime.UtcNow.Ticks.ToString(), null, model);
                var subject = "Contact Message";
                result = await mailClient.SendEmailAsync(ConfigurationManager.AppSettings["adminEmail"], subject, body);
            }
            catch (Exception exception)
            {
                throw new NotImplementedException();
            }
            return result;
        }
    }
}