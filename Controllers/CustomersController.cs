using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.Persistence;
using vidly.ViewModels;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext dbContext;
        public CustomersController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }

        public ActionResult CustomerForm()
        {
            var MembershipTypes = dbContext.membershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                membershipTypes = MembershipTypes,

            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    membershipTypes = dbContext.membershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.id == 0)
            dbContext.Customers.Add(customer);
            else
            {
                var customerInDb = dbContext.Customers.Single(c => c.id == customer.id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

       
        public ViewResult Index()
        {
            var customer = dbContext.Customers.Include(c => c.MembershipType).ToList();
              return View(customer); 
            
        }

        public ActionResult Details(int id)
        {
            var customer = dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,       
                membershipTypes = dbContext.membershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
       
    }
}