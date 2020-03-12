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

            if (!context.Alumnos.Any())
            {
                context.Alumnos.AddOrUpdate(x => x.AlumnoId,
                    new Modelos.Alumno() { Cedula = "12345", NombreAlumno= "Jack" },
                    new Modelos.Alumno() { Cedula = "67890", NombreAlumno = "Louis" }
                );
            }

            if (!context.Cursos.Any())
            {
                context.Cursos.AddOrUpdate(x => x.CursoId,
                    new Modelos.Curso() { Codigo = "001", NombreCurso = ".Net", Activo = 1 },
                    new Modelos.Curso() { Codigo = "002", NombreCurso = "Java", Activo = 1 }
                );
            }

            if (!context.ReservasAlumnos.Any())
            {
                context.ReservasAlumnos.AddOrUpdate(x => x.ReservaAlumnoId,
                    new Modelos.ReservaAlumno() { AlumnoId = 1, CursoId = 1 },
                    new Modelos.ReservaAlumno() { AlumnoId = 1, CursoId = 2 },
                    new Modelos.ReservaAlumno() { AlumnoId = 2, CursoId = 1 },
                    new Modelos.ReservaAlumno() { AlumnoId = 2, CursoId = 2 }
                );
            }

            if (!context.SillasReserva.Any())
            {
                context.SillasReserva.AddOrUpdate(x => x.SillaReservaId,
                    new Modelos.SillaReserva() { ReservaAlumnoId = 1, SillaId = 5 },
                    new Modelos.SillaReserva() { ReservaAlumnoId = 2, SillaId = 16 },
                    new Modelos.SillaReserva() { ReservaAlumnoId = 3, SillaId = 10 },
                    new Modelos.SillaReserva() { ReservaAlumnoId = 4, SillaId = 7 }
                );
            }
        }
    }
}
