using System.Threading.Tasks;

namespace WebApplication1.Services.Abstractions
{
    public interface IMailService
    {
        Task<bool> SendMessage(string userEmail, string userName, string message);
    }
}
