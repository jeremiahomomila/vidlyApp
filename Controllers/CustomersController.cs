using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers/details
        public ActionResult Details()
        {
            var customers = new List<Customer>
            {
                new Customer{ Name = "Jeremiah" },
                new Customer{Name = "Moses"},
                new Customer{Name = "Kelvin"},
                new Customer{Name = "Dad"},
                new Customer{Name = "Mum"},
                new Customer{Name = "Favour"}

            };

              var viewModel = new RandomMovieViewModel
            {
                      customers = customers
              };
              return View(viewModel);
            
        }
    }
}