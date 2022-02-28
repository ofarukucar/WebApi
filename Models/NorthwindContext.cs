using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class NorthwindContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}