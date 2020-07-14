using _2_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4_DataAcces.Contrats
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Pelicula> Peliculas { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Sala> Salas { get; set; }

        public DbSet<Sede> Sedes { get; set; }

        public DbSet<Silla> Sillas { get; set; }

        public DbSet<SillaReserva> SillasReserva { get; set; }
    }
}
