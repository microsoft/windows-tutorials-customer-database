using System;
using CustomerDatabaseTutorial.App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatabaseTutorial.App.Repository
{
    public class CustomerContext : DbContext
    {
        /// <summary>
        /// Creates a new DbContext.
        /// </summary>
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        { }

        /// <summary>
        /// Gets the customers DbSet.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
    }
}
