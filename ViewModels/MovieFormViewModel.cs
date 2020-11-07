using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie movie { get; set; }
        public string Title
        {
            get
            {
                if (movie != null && movie.Id != 0)
                    return "Edit Movie";
                return "New Movie";
            }
        }

    }
}