using System.Threading.Tasks;

namespace WebApplication1.Services.Abstractions
{
    public interface IWebClientHelper
    {
        Task<T> GetWebRequest<T>(string url);
    }
}