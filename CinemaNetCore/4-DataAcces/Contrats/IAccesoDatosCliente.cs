using _2_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _4_DataAcces.Contrats
{
    public interface IAccesoDatosCliente
    {
        Task<int> InsertarCliente(Cliente cliente);

        Task<List<Cliente>> RetornarClientes();

        Task<Cliente> BuscarClienteId(int id);

        Task<Cliente> BuscarClienteCc(string cc);

        Task<int> ActualizarCliente(Cliente cliente);

        Task<int> EliminarCliente(int cedula);

        Task<int> EliminarClienteCc(string cedula);
    }
}
