namespace DataAccess.Contrats
{
    using Models;
    using System.Data.Entity;

    public abstract class Context : DbContext
    {
        public Context()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<LogInUsers> LoginUsers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductRequest> Requests { get; set; }
    }
}
