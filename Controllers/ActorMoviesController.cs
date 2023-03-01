using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMidterm.Data;
using WebMidterm.Models;

namespace WebMidterm.Controllers
{
    public class ActorMoviesController : Controller
    {
        private readonly AppDbContext _context;

        public ActorMoviesController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var actor = _context.ActorMovies.Include(a => a.Actor).Include(a => a.Movie);
            return View(await actor.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ActorMovies == null)
            {
                return NotFound();
            }

            var actorMovie = await _context.ActorMovies
                .Include(a => a.Actor)
                .Include(a => a.Movie)
                .FirstOrDefaultAsync(m => m.ActorId == id);
            if (actorMovie == null)
            {
                return NotFound();
            }

            return View(actorMovie);
        }


        public IActionResult Create()
        {
            ViewBag.ActorId = _context.People; 
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int MovieId,int []PersonId)
        {
            if (ModelState.IsValid)
            {
                foreach (var p in PersonId)
                {
                    ActorMovie actor = new ActorMovie();
                    actor.MovieId = MovieId;
                    actor.ActorId = p;
                    _context.ActorMovies.Add(actor);
                    await _context.SaveChangesAsync();
                }
               
                return RedirectToAction(nameof(Index));
            }
        
            return View();
        }

      
    }
}
