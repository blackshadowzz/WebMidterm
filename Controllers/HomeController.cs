using Microsoft.AspNetCore.Mvc;

namespace WebMidterm.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
