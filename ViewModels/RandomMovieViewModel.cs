using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Movie> ActionMovies { get; set; } 
        public List<Movie> CartoonMovies { get; set; }
        public List<Movie> AmericanSeries { get; set; }
        public List<Customer> customers { get; set; }

    }
}