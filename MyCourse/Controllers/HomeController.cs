using Microsoft.AspNetCore.Mvc;

namespace MyCourse.Controllers 
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Welcome in MyCourse, sopinel page";
            return View();
        }
    }
}