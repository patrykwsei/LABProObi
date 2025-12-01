using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lecture3.Models.Movies;

namespace Lecture3.Controllers
{
    /*
     * Klasa kontrolera korzysta z zależności, które przekazujemy do kontrolera w konstruktorze.
     * Kontener IoC dostarczy instancji tej zależności, jeśli jest taka klasa zarejetrowana.
     * W pliku Program.cs klasa MoviesContext jest zarejestrowana wpisem:
     *     builder.Services.AddDbContext<MoviesContext>(op => ...);
     */
    public class MovieController(MoviesDatabase context) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            return View(await context
                .Movies
                .OrderBy(m=> m.Title)
                .Take(50)
                .Select(m => MovieView.FromEntity(m))
                .ToListAsync());
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieEntity = await context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieEntity == null)
            {
                return NotFound();
            }

            return View(MovieView.FromEntity(movieEntity));
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Budget,Overview,ReleaseDate")] MovieEntity movieEntity)
        {
            if (ModelState.IsValid)
            {
                int id = context.Movies.Max(m => m.Id) + 1;
                movieEntity.Id = id;
                context.Add(movieEntity);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(MovieView.FromEntity(movieEntity));
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieEntity = await context.Movies.FindAsync(id);
            if (movieEntity == null)
            {
                return NotFound();
            }
            return View(MovieView.FromEntity(movieEntity));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Budget,Overview,ReleaseDate")] MovieView model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Movies.Update(model.ToEntity());
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieEntityExists(model.Id))
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
            return View(model);
        }

        private bool MovieEntityExists(int id)
        {
            return context.Movies.Any(e => e.Id == id);
        }
    }
}
