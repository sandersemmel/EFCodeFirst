using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class DatabaseContext: DbContext
    {

        public DatabaseContext() : base("DefaultConnection")
        {
        
            Database.SetInitializer<DatabaseContext>(null);
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<MovieReview> MovieReview { get; set; }
        public DbSet<Movie> Movie { get; set; }

    }
}