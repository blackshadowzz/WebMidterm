using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMidterm.Data;
using WebMidterm.Models;

namespace WebMidterm.Controllers
{
    public class DirectorMoviesController : Controller
    {
        private readonly AppDbContext _context;

        public DirectorMoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.DirectorMovies.Include(d => d.Director).Include(d => d.Movie);
            return View(await appDbContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DirectorMovies == null)
            {
                return NotFound();
            }

            var directorMovie = await _context.DirectorMovies
                .Include(d => d.Director)
                .Include(d => d.Movie)
                .FirstOrDefaultAsync(m => m.DirectorId == id);
            if (directorMovie == null)
            {
                return NotFound();
            }

            return View(directorMovie);
        }


        public IActionResult Create()
        {
            ViewData["DirectorId"] = new SelectList(_context.People, "PersonId", "FirstName","LastName");
            ViewBag.MovieId = _context.Movies;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int DirectorId,int []Id)
        {
            if (ModelState.IsValid)
            {
                foreach( var i in Id)
                {
                    DirectorMovie director=new DirectorMovie();
                    director.DirectorId = DirectorId;
                    director.MovieId=i;
                    _context.Add(director);
                    await _context.SaveChangesAsync();
                }
            
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


    }
}
