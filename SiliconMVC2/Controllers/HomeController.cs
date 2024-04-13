using Microsoft.AspNetCore.Mvc;

namespace SiliconMVC2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
