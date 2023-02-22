using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MoviesContext moviesContext { get; set; }

        public HomeController(MoviesContext context)
        {
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
        public IActionResult MovieEntry()
        {
            //Save categories to viewBag
            ViewBag.Categories = moviesContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieEntry(MovieEntry entry)
        {
            //if the entry passes validation
            if (ModelState.IsValid)
            {
                //add a new entry
                moviesContext.Add(entry);
                moviesContext.SaveChanges();

                //show confirmation page
                return View("ConfirmationPage", entry);
            }
            else //otherwise, return to movie entry view
            {
                //Save categories to viewBag
                ViewBag.Categories = moviesContext.Categories.ToList();
                return View(entry);
            }

            
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            //retrieve all  movie entries
            var movies = moviesContext.Entries
                .Include(x => x.Category)

                //This could be included to filter database entries by a certain attribute value
                //.Where(x => x.Edited == false)
                
                //order movies by title
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit (int entryid)
        {
            //Save categories to viewBag
            ViewBag.Categories = moviesContext.Categories.ToList();

            //Find a specific record by the entry id, passed in from view
            var entry = moviesContext.Entries.Single(x => x.EntryId == entryid);

            return View("MovieEntry", entry);
        }

        [HttpPost]
        public IActionResult Edit(MovieEntry entry)
        {
            //if the entry passes validation
            if (ModelState.IsValid)
            {
                //update entry
                moviesContext.Update(entry);
                moviesContext.SaveChanges();

                //return to movie list
                return RedirectToAction("MovieList");
            }
            else //otherwise, return to movie entry view
            {
                //Save categories to viewBag
                ViewBag.Categories = moviesContext.Categories.ToList();
                return View("MovieEntry", entry);
            }
        }

        [HttpGet]
        public IActionResult Delete(int entryid)
        {
            //Find a specific record by the entry id, passed in from view
            var entry = moviesContext.Entries.Single(x => x.EntryId == entryid);

            return View(entry);
        }

        [HttpPost]
        public IActionResult Delete(MovieEntry entry)
        {
            //delete entry and save changes
            moviesContext.Entries.Remove(entry);
            moviesContext.SaveChanges();

            //return to the movie list
            return RedirectToAction("MovieList");
        }
    }
}
