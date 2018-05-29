using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Services.Abstractions;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IImdbService imdbService;
        private IMailService iMailService;

        public HomeController(IImdbService ImdbServicel, IMailService ImailService)
        {
            imdbService = ImdbServicel;
            iMailService = ImailService;
        }

        [HttpPost]
        public async Task<ActionResult> GetRandomFilm()
        {
            try
            {
                var model = await imdbService.GetRandomFilm();
                var c = Json(model);
                return Json(model);
            }
            catch
            {
                return null;
            }           
        }

        [HttpPost]
        public async Task<ActionResult> GetFilmByName(string filmName)
        {
            try
            {
                var model = await imdbService.GetFilmByName(filmName);
                var c = Json(model);
                return Json(model);
            }
            catch {
                return null;
            }
        }

        [HttpPost]
        public async Task<bool> SendUserMessage(string userEmail, string userName, string userMessage)
        {
            var result = false;
            try
            {
               result = await iMailService.SendMessage(userEmail, userName, userMessage);
            }
            catch
            {
                throw new NotImplementedException();
            }
            return result;
        }

        public async Task<ActionResult> Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}