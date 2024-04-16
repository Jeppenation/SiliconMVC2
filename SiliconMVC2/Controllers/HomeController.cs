using Microsoft.AspNetCore.Mvc;
using SiliconMVC2.ViewModels;

namespace SiliconMVC2.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            ViewData["Title"] = "Home Page";

            return View(model);
        }
    }
}
