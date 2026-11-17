
using K22c_day6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class MoviesController : Controller
{
    private readonly K22c_day6Context _context;

    public MoviesController(K22c_day6Context context)
    {
        _context = context;
    }

    // GET: MOVIESS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Movies.ToListAsync());
    }

    // GET: MOVIESS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movies = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movies == null)
        {
            return NotFound();
        }

        return View(movies);
    }

    // GET: MOVIESS/Create
    public IActionResult Create()
    {
        ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name");
        return View();
    }

    // POST: MOVIESS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,GenreId")] Movies movies)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Name", movies.GenreId);
        return View(movies);
    }

    // GET: MOVIESS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movies = await _context.Movies.FindAsync(id);
        if (movies == null)
        {
            return NotFound();
        }
        return View(movies);
    }

    // POST: MOVIESS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,ReleaseDate,GenreId,Genre")] Movies movies)
    {
        if (id != movies.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(movies);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(movies.Id))
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
        return View(movies);
    }

    // GET: MOVIESS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movies = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movies == null)
        {
            return NotFound();
        }

        return View(movies);
    }

    // POST: MOVIESS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var movies = await _context.Movies.FindAsync(id);
        if (movies != null)
        {
            _context.Movies.Remove(movies);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MoviesExists(int? id)
    {
        return _context.Movies.Any(e => e.Id == id);
    }
}
