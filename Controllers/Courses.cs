using Microsoft.AspNetCore.Mvc;

namespace Gibjohn_Tutoring.Controllers
{
    public class Courses : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
