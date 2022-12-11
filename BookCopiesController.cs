using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApplication.Data;
using LibraryApplication.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryApplication.Controllers
{
    public class BookCopiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookCopiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookCopies
        [Authorize]

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookCopies.Include(b => b.bookObj).Include(b => b.libObj);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookCopies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookCopies == null)
            {
                return NotFound();
            }

            var bookCopies = await _context.BookCopies
                .Include(b => b.bookObj)
                .Include(b => b.libObj)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCopies == null)
            {
                return NotFound();
            }

            return View(bookCopies);
        }

        // GET: BookCopies/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title");
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Name");
            return View();
        }

        // POST: BookCopies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,NumberOfCopies,LibraryId")] BookCopies bookCopies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCopies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title", bookCopies.BookId);
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Name", bookCopies.LibraryId);
            return View(bookCopies);
        }

        // GET: BookCopies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookCopies == null)
            {
                return NotFound();
            }

            var bookCopies = await _context.BookCopies.FindAsync(id);
            if (bookCopies == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title", bookCopies.BookId);
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Name", bookCopies.LibraryId);
            return View(bookCopies);
        }

        // POST: BookCopies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,NumberOfCopies,LibraryId")] BookCopies bookCopies)
        {
            if (id != bookCopies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCopies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCopiesExists(bookCopies.Id))
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
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title", bookCopies.BookId);
            ViewData["LibraryId"] = new SelectList(_context.Library, "Id", "Name", bookCopies.LibraryId);
            return View(bookCopies);
        }

        // GET: BookCopies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookCopies == null)
            {
                return NotFound();
            }

            var bookCopies = await _context.BookCopies
                .Include(b => b.bookObj)
                .Include(b => b.libObj)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCopies == null)
            {
                return NotFound();
            }

            return View(bookCopies);
        }

        // POST: BookCopies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookCopies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BookCopies'  is null.");
            }
            var bookCopies = await _context.BookCopies.FindAsync(id);
            if (bookCopies != null)
            {
                _context.BookCopies.Remove(bookCopies);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCopiesExists(int id)
        {
          return _context.BookCopies.Any(e => e.Id == id);
        }
    }
}
