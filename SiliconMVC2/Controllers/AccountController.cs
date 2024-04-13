using Microsoft.AspNetCore.Mvc;

namespace SiliconMVC2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
