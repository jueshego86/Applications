using _2_Models;
using _2_Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3_Facade.Contracts
{
    public interface IFachadaCliente
    {
        Task<int> InsertarCliente(Cliente cliente);

        Task<Cliente> ObtenerCliente(int id);

        Task<Cliente> ObtenerClienteCc(string cc);

        Task<List<Cliente>> ListarClientes();

        Task<bool> EliminarCliente(int id);

        Task<bool> ActualizarCliente(Cliente dtoCliente);
    }
}
