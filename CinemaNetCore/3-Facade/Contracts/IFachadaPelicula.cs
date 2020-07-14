using _2_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3_Facade.Contracts
{
    public interface IFachadaPelicula
    {
        Task<int> InsertarPelicula(Pelicula pelicula);

        Task<Pelicula> ObtenerPelicula(int id);

        Task<List<Pelicula>> ListarPeliculas();

        Task<bool> EliminarPelicula(int id);

        Task<bool> ActualizarPelicula(Pelicula pelicula);
    }
}
