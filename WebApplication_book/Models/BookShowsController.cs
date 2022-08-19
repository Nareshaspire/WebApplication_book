using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_book.Data;

namespace WebApplication_book.Models
{
    public class BookShowsController : Controller
    {
        private readonly WebApplication_bookContext _context;

        public BookShowsController(WebApplication_bookContext context)
        {
            _context = context;
        }

        // GET: BookShows
        public async Task<IActionResult> Index()
        {
              return _context.BookShow != null ? 
                          View(await _context.BookShow.ToListAsync()) :
                          Problem("Entity set 'WebApplication_bookContext.BookShow'  is null.");
        }

        // GET: BookShows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookShow == null)
            {
                return NotFound();
            }

            var bookShow = await _context.BookShow
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bookShow == null)
            {
                return NotFound();
            }

            return View(bookShow);
        }

        // GET: BookShows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Genre,Rating,GoodreadsURLS")] BookShow bookShow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookShow);
        }

        // GET: BookShows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookShow == null)
            {
                return NotFound();
            }

            var bookShow = await _context.BookShow.FindAsync(id);
            if (bookShow == null)
            {
                return NotFound();
            }
            return View(bookShow);
        }

        // POST: BookShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Genre,Rating,GoodreadsURLS")] BookShow bookShow)
        {
            if (id != bookShow.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookShowExists(bookShow.ID))
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
            return View(bookShow);
        }

        // GET: BookShows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookShow == null)
            {
                return NotFound();
            }

            var bookShow = await _context.BookShow
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bookShow == null)
            {
                return NotFound();
            }

            return View(bookShow);
        }

        // POST: BookShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookShow == null)
            {
                return Problem("Entity set 'WebApplication_bookContext.BookShow'  is null.");
            }
            var bookShow = await _context.BookShow.FindAsync(id);
            if (bookShow != null)
            {
                _context.BookShow.Remove(bookShow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookShowExists(int id)
        {
          return (_context.BookShow?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
