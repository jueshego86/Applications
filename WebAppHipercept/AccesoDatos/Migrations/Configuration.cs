namespace DataAccess.Migrations
{
    using DataAccess.SqlServer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContextSQLServer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContextSQLServer context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            if (!context.Products.Any())
            {
                context.Products.AddOrUpdate(p => p.ProductId,
                new Models.Product() { Name = "Product 1", Stock = 2 },
                new Models.Product() { Name = "Product 2", Stock = 1 },
                new Models.Product() { Name = "Product 3", Stock = 50 },
                new Models.Product() { Name = "Product 4", Stock = 1 }
                );
            }
        }
    }
}
