using Models;
using Models.DTO;
using Facade.Contracts;
using DataAcces.Contrats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class FachadaUsuario : IFachadaUsuario
    {
        private IAccesoDatosUsuario accesoDatosUsuario;

        public FachadaUsuario(IAccesoDatosUsuario accesoDatosUsuario)
        {
            this.accesoDatosUsuario = accesoDatosUsuario;
        }

        public async Task<Usuario> InsertarUsuario(Usuario usuario)
        {
            return await this.accesoDatosUsuario.InsertarUsuario(usuario);
        }

        public async Task<Usuario> BuscarUsuario(string nombre)
        {
            return await this.accesoDatosUsuario.BuscarUsuario(nombre);
        }

        public async Task<Usuario> BuscarUsuarioLogin(DtoLogin dtoLogin)
        {
            return await this.accesoDatosUsuario.BuscarUsuarioLogin(dtoLogin);
        }

        public async Task<List<Usuario>> ListarUsuarios()
        {
            return await this.accesoDatosUsuario.RetornarUsuarios();
        }

        public async Task<bool> EliminarUsuario(string nombre)
        {
            return await this.accesoDatosUsuario.EliminarUsuario(nombre) == 1;
        }

        public async Task<bool> ActualizarUsuario(Usuario usuario)
        {
            return await this.accesoDatosUsuario.ActualizarUsuario(usuario) == 1;
        }

        public async Task<bool> Transferir(Usuario remitente, Usuario destinatario, decimal valor)
        {
            return await this.accesoDatosUsuario.Transferir(remitente, destinatario, valor);
        }
    }
}
