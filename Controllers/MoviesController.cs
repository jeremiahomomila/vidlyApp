using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.Persistence;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext dbContext;
        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Movies/Random
        public ViewResult Index()
        {
            var movie = dbContext.Movies.Include(m => m.Genre).ToList();
                           
            return View(movie);
        }

        public ActionResult MovieForm()
        {
            var Genres = dbContext.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                movie = new Movie() { DateAdded = DateTime.Now},
                Genres = Genres,

            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(c => c.Id == id);
                if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                movie = movie,
                Genres = dbContext.Genres.ToList()
            };
            return View("MovieForm", viewModel);

        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    movie = movie,
                    Genres = dbContext.Genres.ToList()
                };
               return View("MovieForm", viewModel);
            }
              
            if (movie.Id == 0)
                dbContext.Movies.Add(movie);
            else
            {
                var MovieInDb = dbContext.Movies.Single(c => c.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.GenreId = movie.GenreId;
                MovieInDb.DateAdded = movie.DateAdded;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.NumberInStock = movie.NumberInStock;

            }
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }

      
        public ActionResult Details(int id) 
        {
            var movie = dbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

  

                    
    }
}