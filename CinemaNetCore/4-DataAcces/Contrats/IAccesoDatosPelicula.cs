using _2_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _4_DataAcces.Contrats
{
    public interface IAccesoDatosPelicula
    {
        Task<int> InsertarPelicula(Pelicula pelicula);

        Task<Pelicula> BuscarPelicula(int id);

        Task<int> ActualizarPelicula(Pelicula pelicula);

        Task<List<Pelicula>> RetornarPeliculas();

        Task<int> EliminarPelicula(int id);
    }
}
