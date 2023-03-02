using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMidterm.Data;

namespace WebMidterm.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var movie = _context.Movies.Include(m => m.MovieArts);
            //var movie=_context.MovieArts.Include(x => x.Movie);
            return View(await movie.ToListAsync());
        }
    }
}
