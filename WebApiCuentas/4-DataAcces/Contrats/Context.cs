using Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Contrats
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
