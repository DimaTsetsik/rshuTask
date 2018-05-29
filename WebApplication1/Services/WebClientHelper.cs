using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WebApplication1.Services.Abstractions;

namespace WebApplication1.Services
{
    public class WebClientHelper : IWebClientHelper
    {
        public async Task<T> GetWebRequest<T>(string url)
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                JavaScriptSerializer oJS = new JavaScriptSerializer();
                var imdbEntity = oJS.Deserialize<T>(json);

                return imdbEntity;
            }
        }
    }
}