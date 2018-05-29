using System;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WebApplication1.Models;
using WebApplication1.Services.Abstractions;

namespace WebApplication1.Services
{
    public class ImdbService : IImdbService
    {
        public async Task<ImdbEntity> GetFilmByName(string filmName)
        {
            string url = $"{ConfigurationManager.AppSettings["apiUrl"]}{filmName}&{ConfigurationManager.AppSettings["apiToken"]}";
            var result = await InitWebClientHelper<ImdbEntity>(url);

            return result;
        }

        public async Task<ImdbEntity> GetRandomFilm()
        {
            Random random = new Random();
            string url =  $"{ConfigurationManager.AppSettings["apiUrl"]}tt0{random.Next(11, 88)}2452&{ConfigurationManager.AppSettings["apiToken"]}";
            var result = await InitWebClientHelper<ImdbEntity>(url);

            return result;
        }

        public async Task<T> InitWebClientHelper<T>(string url) {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    var json = wc.DownloadString(url);
                    JavaScriptSerializer oJS = new JavaScriptSerializer();
                    var imdbEntity = oJS.Deserialize<T>(json);

                    return imdbEntity;
                }
                catch (Exception e)
                {
                    throw new Exception($"Internal fucked error: {e.Data}");
                }
            }
        }
    }
}