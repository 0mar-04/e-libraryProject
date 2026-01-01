using e_libraryProject.Data;
using e_libraryProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace e_libraryProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookAuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookAuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookAuthors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookAuthors
                .Include(b => b.Author)
                .Include(b => b.Book);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var bookAuthor = await _context.BookAuthors
                .Include(b => b.Author)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bookAuthor == null) return NotFound();

            return View(bookAuthor);
        }

        // GET: BookAuthors/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title");
            return View();
        }

        // POST: BookAuthors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,AuthorId,Note")] BookAuthor bookAuthor)
        {
            bookAuthor.AddedAt = DateTime.Now;

            bool exists = await _context.BookAuthors
                .AnyAsync(x => x.BookId == bookAuthor.BookId && x.AuthorId == bookAuthor.AuthorId);

            if (exists)
                ModelState.AddModelError("", "This author is already linked to this book.");

            if (ModelState.IsValid)
            {
                _context.Add(bookAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // GET: BookAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var bookAuthor = await _context.BookAuthors.FindAsync(id);
            if (bookAuthor == null) return NotFound();

            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // POST: BookAuthors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,AuthorId,AddedAt,Note")] BookAuthor bookAuthor)
        {
            if (id != bookAuthor.Id) return NotFound();

            // Prevent duplicate BookId+AuthorId (excluding this row)
            bool duplicate = await _context.BookAuthors.AnyAsync(x =>
                x.Id != bookAuthor.Id &&
                x.BookId == bookAuthor.BookId &&
                x.AuthorId == bookAuthor.AuthorId);

            if (duplicate)
            {
                ModelState.AddModelError("", "This author is already linked to this book.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookAuthorExists(bookAuthor.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name", bookAuthor.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", bookAuthor.BookId);
            return View(bookAuthor);
        }

        // GET: BookAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var bookAuthor = await _context.BookAuthors
                .Include(b => b.Author)
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bookAuthor == null) return NotFound();

            return View(bookAuthor);
        }

        // POST: BookAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookAuthor = await _context.BookAuthors.FindAsync(id);
            if (bookAuthor != null)
            {
                _context.BookAuthors.Remove(bookAuthor);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BookAuthorExists(int id)
        {
            return _context.BookAuthors.Any(e => e.Id == id);
        }
    }
}
