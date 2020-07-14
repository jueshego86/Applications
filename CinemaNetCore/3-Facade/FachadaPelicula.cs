using _2_Models;
using _3_Facade.Contracts;
using _4_DataAcces;
using _4_DataAcces.Contrats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3_Facade
{
    public class FachadaPelicula : IFachadaPelicula
    {
        private IAccesoDatosPelicula _accesoDatosPelicula;

        public FachadaPelicula(IAccesoDatosPelicula accesoDatosPelicula)
        {
            _accesoDatosPelicula = accesoDatosPelicula;
        }

        public async Task<bool> ActualizarPelicula(Pelicula pelicula)
        {
            return await _accesoDatosPelicula.ActualizarPelicula(pelicula) == 1;
        }

        public async Task<bool> EliminarPelicula(int id)
        {
            return await _accesoDatosPelicula.EliminarPelicula(id) == 1;
        }

        public async Task<int> InsertarPelicula(Pelicula pelicula)
        {
            return await _accesoDatosPelicula.InsertarPelicula(pelicula);
        }

        public async Task<List<Pelicula>> ListarPeliculas()
        {
            return await _accesoDatosPelicula.RetornarPeliculas();
        }

        public async Task<Pelicula> ObtenerPelicula(int id)
        {
            return await _accesoDatosPelicula.BuscarPelicula(id);
        }
    }
}
