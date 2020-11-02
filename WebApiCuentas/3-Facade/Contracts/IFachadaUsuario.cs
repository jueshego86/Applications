using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Contracts
{
    public interface IFachadaUsuario
    {
        Task<Usuario> InsertarUsuario(Usuario usuario);

        Task<Usuario> BuscarUsuario(string nombre);

        Task<Usuario> BuscarUsuarioLogin(DtoLogin dtoLogin);

        Task<List<Usuario>> ListarUsuarios();

        Task<bool> EliminarUsuario(string nombre);

        Task<bool> ActualizarUsuario(Usuario usuario);

        Task<bool> Transferir(Usuario remitente, Usuario destinatario, decimal valor);
    }
}
