using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMidterm.Data;
using WebMidterm.Models;

namespace WebMidterm.Controllers
{
    public class MovieArtsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public MovieArtsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MovieArts.Include(m => m.Movie);
            return View(await appDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovieArts == null)
            {
                return NotFound();
            }

            var movieArt = await _context.MovieArts
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieArt == null)
            {
                return NotFound();
            }

            return View(movieArt);
        }


        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieArt movieArt)
        {
            if (ModelState.IsValid)
            {

                string fileName=FileUpload(movieArt);
                movieArt.ArtistUrl = fileName;
                _context.Attach(movieArt);
                _context.Entry(movieArt).State=EntityState.Added;
                //_context.MovieArts.Add(movieArt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieArt.MovieId);
            return View(movieArt);
        }
        private string FileUpload(MovieArt art)
        {
            string fileName = null;
            if (art.FrontImage != null)
            {
                string fileFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + art.FrontImage.FileName;
                string filePath = Path.Combine(fileFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    art.FrontImage.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovieArts == null)
            {
                return NotFound();
            }

            var movieArt = await _context.MovieArts.FindAsync(id);
          
            if (movieArt == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieArt.MovieId);
            return View(movieArt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieArt movieArt)
        {
            if (id != movieArt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = FileUpload(movieArt);
                    if(fileName != null)
                    {
                        movieArt.ArtistUrl = fileName;
                    }
                    _context.Attach(movieArt);
                    _context.Entry(movieArt).State = EntityState.Added;
                    //_context.MovieArts.Add(movieArt);
                    _context.Update(movieArt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieArtExists(movieArt.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", movieArt.MovieId);
            return View(movieArt);
        }


        public async Task<IActionResult> Delete(int? id)
        {

            var movieArt = await _context.MovieArts.FindAsync(id);
            if (movieArt == null)
            {
                return BadRequest();
            }
            _context.MovieArts.Remove(movieArt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieArtExists(int id)
        {
          return (_context.MovieArts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
