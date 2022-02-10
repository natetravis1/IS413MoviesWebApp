using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext movieContext { get; set; }

        //constructor
        public HomeController(MovieContext movie)
        {
            movieContext = movie;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies ()
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Movies(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(ar);
                movieContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();

                return View();
            }
        }

        public IActionResult MyPodcasts ()
        {
            return View();
        }

        public IActionResult MovieList ()
        {
            var movies = movieContext.Responses.Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit (int applicationid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movie = movieContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse info)
        {
            movieContext.Update(info);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            var movie = movieContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            movieContext.Responses.Remove(ar);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
