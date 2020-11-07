using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("VidlyApp")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> membershipTypes { get; set; }
    }
   
}