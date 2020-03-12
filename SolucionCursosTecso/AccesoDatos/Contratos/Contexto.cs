
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Contratos
{
    public abstract class Contexto : DbContext
    {
        public Contexto()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //evitar el borrado en cascada->levanta excepcion por violacion de integridad referencial
        //    Database.SetInitializer<Contexto>(new MigrateDatabaseToLatestVersion<Contexto, Configuration>());
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //}

        public DbSet<Silla> Sillas { get; set; }

        public DbSet<SillaReserva> SillasReserva { get; set; }

        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<ReservaAlumno> ReservasAlumnos { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<NotaCurso> NotasCursos { get; set; }
    }
}
