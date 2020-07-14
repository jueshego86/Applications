using _2_Models;
using _4_DataAcces.Contrats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _4_DataAcces
{
    public class AccesoDatosPelicula : IAccesoDatosPelicula
    {
        private Context _contexto;

        public AccesoDatosPelicula(Context contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> ActualizarPelicula(Pelicula pelicula)
        {
            this._contexto.Entry(pelicula).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync();
        }

        public async Task<Pelicula> BuscarPelicula(int id)
        {
            return await _contexto.Peliculas.FindAsync(id);
        }

        public async Task<int> EliminarPelicula(int id)
        {
            _contexto.Peliculas.Remove(_contexto.Peliculas.Find(id));
            return await _contexto.SaveChangesAsync();
        }

        public async Task<int> InsertarPelicula(Pelicula pelicula)
        {
            try
            {
                _contexto.Peliculas.Add(pelicula);
                await _contexto.SaveChangesAsync();
                return pelicula.PeliculaId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Pelicula>> RetornarPeliculas()
        {
            return await _contexto.Peliculas.ToListAsync();
        }
    }
}
