using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission06_edemaere.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_edemaere.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesContext moviesContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MoviesContext context)
        {
            _logger = logger;
            moviesContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieEntry entry)
        {
            moviesContext.Add(entry);
            moviesContext.SaveChanges();

            return View("ConfirmationPage", entry);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
