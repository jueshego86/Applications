using _2_Models;
using _4_DataAcces.Contrats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_DataAcces
{
    public class AccesoDatosCliente : IAccesoDatosCliente
    {
        private Context _contexto;

        public AccesoDatosCliente(Context contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> ActualizarCliente(Cliente cliente)
        {
            this._contexto.Entry(cliente).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync();
        }

        public async Task<Cliente> BuscarClienteId(int id)
        {
            return await _contexto.Clientes.FindAsync(id);
        }

        public async Task<Cliente> BuscarClienteCc(string cc)
        {
            return await _contexto.Clientes.FirstOrDefaultAsync(c => c.Cedula == cc);
        }

        public async Task<int> EliminarCliente(int id)
        {
            _contexto.Clientes.Remove(_contexto.Clientes.Find(id));
            return await _contexto.SaveChangesAsync();
        }

        public async Task<int> EliminarClienteCc(string cc)
        {
            _contexto.Clientes.Remove(_contexto.Clientes.FirstOrDefault(c => c.Cedula == cc));
            return await _contexto.SaveChangesAsync();
        }

        public async Task<int> InsertarCliente(Cliente cliente)
        {
            try
            {
                _contexto.Clientes.Add(cliente);
                await _contexto.SaveChangesAsync();
                return cliente.ClienteId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Cliente>> RetornarClientes()
        {
            return await _contexto.Clientes.ToListAsync();
        }
    }
}
