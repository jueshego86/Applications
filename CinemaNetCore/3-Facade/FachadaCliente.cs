using _2_Models;
using _2_Models.DTO;
using _3_Facade.Contracts;
using _4_DataAcces.Contrats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _3_Facade
{
    public class FachadaCliente : IFachadaCliente
    {
        private IAccesoDatosCliente _accesoDatosCliente;

        public FachadaCliente(IAccesoDatosCliente accesoDatosCliente)
        {
            _accesoDatosCliente = accesoDatosCliente;
        }

        public async Task<int> InsertarCliente(Cliente cliente)
        {
            return await _accesoDatosCliente.InsertarCliente(cliente);
        }

        public async Task<Cliente> ObtenerCliente(int id)
        {
            return await _accesoDatosCliente.BuscarClienteId(id);
        }

        public async Task<Cliente> ObtenerClienteCc(string cc)
        {
            return await _accesoDatosCliente.BuscarClienteCc(cc);
        }

        public async Task<List<Cliente>> ListarClientes()
        {
            return await _accesoDatosCliente.RetornarClientes();
        }

        public async Task<bool> EliminarCliente(int id)
        {
            return await _accesoDatosCliente.EliminarCliente(id) == 1;
        }

        public async Task<bool> ActualizarCliente(Cliente dtoCliente)
        {
            return await _accesoDatosCliente.ActualizarCliente(dtoCliente) == 1;
        }
    }
}
