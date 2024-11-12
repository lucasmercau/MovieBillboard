using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using MovieBillboard.Data;
using MovieBillboard.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace MovieBillboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieContext _context;

        public HomeController(ILogger<HomeController> logger, MovieContext context)
        {
            _logger = logger;
            _context = context;
        }

        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }

        public async Task<IActionResult> Index()
        {
            if (_context.Movie == null)
            {
                return Problem("Entity set 'MovieContext.Movie' is null.");
            }

            var movies = await _context.Movie.ToListAsync();

            if (!movies.Any())
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            var random = new Random();
            var randomMovie = movies.OrderBy(m => random.Next()).FirstOrDefault();

            return View(randomMovie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
