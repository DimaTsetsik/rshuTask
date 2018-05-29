using System;
using System.Configuration;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services.Abstractions;

namespace WebApplication1.Services
{
    public class ImdbService : IImdbService
    {
        private IWebClientHelper webClientHelper;

        public ImdbService(IWebClientHelper webClientHelper)
        {
            this.webClientHelper = webClientHelper;
        }

        public async Task<ImdbEntity> GetFilmByName(string filmName)
        {
            try
            {
                string url = $"{ConfigurationManager.AppSettings["apiUrl"]}{filmName}&{ConfigurationManager.AppSettings["apiToken"]}";
                var result = await webClientHelper.GetWebRequest<ImdbEntity>(url);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Internal fucked error: {e.Data}");
            }
        }

        public async Task<ImdbEntity> GetRandomFilm()
        {
            try
            {
                Random random = new Random();
                string url = $"{ConfigurationManager.AppSettings["apiUrl"]}tt0{random.Next(11, 88)}2452&{ConfigurationManager.AppSettings["apiToken"]}";
                var result = await webClientHelper.GetWebRequest<ImdbEntity>(url);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Internal fucked error: {e.Data}");
            }
        }
    }
}