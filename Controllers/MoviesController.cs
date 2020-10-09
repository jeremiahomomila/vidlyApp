using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var  ActionMovies = new List<Movie>
            {
                new Movie {Name = "Avengers"},
                new Movie {Name = "Spider Man "},
                new Movie {Name = "Fast And furious "},
                new Movie {Name = "Forbidden Kingdom"}
            };

            var CartoonMovies = new List<Movie>
            {
                new Movie {Name = "The Lion King"},
                new Movie {Name = "Shrek"},
                new Movie {Name = "Tom & Jerry"},
                new Movie {Name = "The Boss Baby"},
            };

            var AmericanSeries = new List<Movie>
            {
                new Movie {Name = "PrisonBreak"},
                new Movie {Name = "Money Heist"}
            };

        

            var viewModel = new RandomMovieViewModel
            {
                ActionMovies = ActionMovies,
                CartoonMovies = CartoonMovies,
                AmericanSeries = AmericanSeries
                
                
            };
            return View(viewModel);
        }

  
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month); 
        }


                    
    }
}