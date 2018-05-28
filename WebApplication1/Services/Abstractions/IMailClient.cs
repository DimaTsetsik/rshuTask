using System;
using System.Threading.Tasks;

namespace WebApplication1.Services.Abstractions
{
    /// <summary>
    /// Represents an interface of mail client
    /// </summary>
    interface IMailClient
    {
        /// <summary>
        /// Sends the email asynchronously
        /// </summary>
        /// <param name="receiverAddress">Email address of receiver</param>
        /// <param name="subject">The email subject</param>
        /// <param name="body">The email message</param>
        /// <returns>Status of sent email</returns>
        Task<bool> SendEmailAsync(string receiverAddress, string subject, string body);

        /// <summary>
        /// Sends the email
        /// </summary>
        /// <param name="receiverAddress">Email address of receiver</param>
        /// <param name="subject">The email subject</param>
        /// <param name="body">The email message</param>
        /// <returns>Status of sent email</returns>
        bool SendEmail(string receiverAddress, string subject, string body);
    }
}
