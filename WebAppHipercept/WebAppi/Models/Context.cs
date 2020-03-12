using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class ContextSQLServer : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}