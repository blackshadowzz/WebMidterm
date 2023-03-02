using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMidterm.Data;

namespace WebMidterm.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var movie = _dbContext.Movies.Include(m => m.MovieArts);
            //var movie=_context.MovieArts.Include(x => x.Movie);
            return View(await movie.ToListAsync());
        }
    }
}
