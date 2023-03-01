using Microsoft.AspNetCore.Mvc;

namespace WebMidterm.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
