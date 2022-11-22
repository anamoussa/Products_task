using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            ViewBag.Title = "Home  | About";

            ViewData["Desc"] = "This Is About Us Page Which Will Enclude Some" +
                "Info About Our Orginization and Our Apps";
            return View("About");
        }
        public IActionResult ContactUs()
        {
            ViewBag.Title = "Home  | Contact Us";
            return View();
        }
    }
}
