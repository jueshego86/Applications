namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AccesoDatos.SqlServer.ContextoSQLServer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AccesoDatos.SqlServer.ContextoSQLServer context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Sillas.Any())
            {
                context.Sillas.AddOrUpdate(x => x.SillaId,
                new Modelos.Silla() { Codigo = "A1" },
                new Modelos.Silla() { Codigo = "A2" },
                new Modelos.Silla() { Codigo = "A3" },
                new Modelos.Silla() { Codigo = "A4" },
                new Modelos.Silla() { Codigo = "A5" },
                new Modelos.Silla() { Codigo = "B1" },
                new Modelos.Silla() { Codigo = "B2" },
                new Modelos.Silla() { Codigo = "B3" },
                new Modelos.Silla() { Codigo = "B4" },
                new Modelos.Silla() { Codigo = "B5" },
                new Modelos.Silla() { Codigo = "C1" },
                new Modelos.Silla() { Codigo = "C2" },
                new Modelos.Silla() { Codigo = "C3" },
                new Modelos.Silla() { Codigo = "C4" },
                new Modelos.Silla() { Codigo = "C5" },
                new Modelos.Silla() { Codigo = "D1" },
                new Modelos.Silla() { Codigo = "D2" },
                new Modelos.Silla() { Codigo = "D3" },
                new Modelos.Silla() { Codigo = "D4" },
                new Modelos.Silla() { Codigo = "D5" }
                );
            }
        }
    }
}
