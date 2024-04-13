using Microsoft.AspNetCore.Mvc;

namespace SiliconMVC2.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
