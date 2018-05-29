using System;
using System.Configuration;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services.Abstractions;

namespace WebApplication1.Services
{
    public class MoviedbService : IMoviedbService
    {
        private IWebClientHelper webClientHelper;

        public MoviedbService(IWebClientHelper webClientHelper)
        {
            this.webClientHelper = webClientHelper;
        }

        public async Task<ThemoviedbEntity> GetRandomFilm()
        {
            try
            {
                Random random = new Random();
                string url = $"{ConfigurationManager.AppSettings["apiUrl2"]}{random.Next(2, 980)}?api_key={ConfigurationManager.AppSettings["themoviedbKey"]}";
                var result = await webClientHelper.GetWebRequest<ThemoviedbEntity>(url);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Internal fucked error: {e.Data}");
            }
        }
    }
}