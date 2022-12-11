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
    public class LendingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LendingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lending
        [Authorize]

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lending.Include(l => l.bookObj).Include(l => l.clientObj);
            bager();
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lending/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lending == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending
                .Include(l => l.bookObj)
                .Include(l => l.clientObj)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // GET: Lending/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title");
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
            return View();
        }

        // POST: Lending/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,ClientId,DatumZajmuvanje,DatumVratena")] Lending lending)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lending);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title", lending.BookId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", lending.ClientId);
            return View(lending);
        }

        // GET: Lending/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lending == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending.FindAsync(id);
            if (lending == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title", lending.BookId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", lending.ClientId);
            return View(lending);
        }

        // POST: Lending/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,ClientId,DatumZajmuvanje,DatumVratena")] Lending lending)
        {
            if (id != lending.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lending);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LendingExists(lending.Id))
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
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Title", lending.BookId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", lending.ClientId);
            return View(lending);
        }

        // GET: Lending/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lending == null)
            {
                return NotFound();
            }

            var lending = await _context.Lending
                .Include(l => l.bookObj)
                .Include(l => l.clientObj)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lending == null)
            {
                return NotFound();
            }

            return View(lending);
        }

        // POST: Lending/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lending == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Lending'  is null.");
            }
            var lending = await _context.Lending.FindAsync(id);
            if (lending != null)
            {
                _context.Lending.Remove(lending);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LendingExists(int id)
        {
          return _context.Lending.Any(e => e.Id == id);
        }
        public void bager()
        {
            Lending lend = new Lending();
            var returned = lend.DatumVratena <= lend.DatumZajmuvanje;
            var notreturned = lend.DatumVratena > lend.DatumZajmuvanje;

            if (returned)
            {
                ViewBag.CountReturned = _context.Lending.Count();

                if (notreturned)
                {
                    ViewBag.CountNotReturned = _context.Lending.Count();
                }
            }
            
       }
    }
}
