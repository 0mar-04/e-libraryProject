using e_libraryProject.Data;
using e_libraryProject.Models.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_libraryProject.Controllers
{

    [Authorize]
    [Route("reports")]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("books-by-status")]
        public async Task<IActionResult> BooksByStatus()
        {
            var groups = await _context.Books
                .GroupBy(b => b.Status)
                .Select(g => new StatusGroup
                {
                    Status = g.Key,
                    Count = g.Count(),
                    Books = g.OrderBy(x => x.Title)
                             .Select(x => new BookItem
                             {
                                 Id = x.Id,
                                 Title = x.Title
                             })
                             .ToList()
                })
                .OrderByDescending(g => g.Count)
                .ThenBy(g => g.Status.ToString())
                .ToListAsync();

            var total = groups.Sum(g => g.Count);
            var mostCommon = groups.FirstOrDefault()?.Status;


            var page = new BooksByStatusPage
            {
                TotalBooks = total,
                MostCommonStatus = mostCommon,
                Groups = groups
            };


            return View(page);
        }
    }
}
