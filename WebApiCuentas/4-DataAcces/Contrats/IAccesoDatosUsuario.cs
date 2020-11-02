using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Contrats
{
    public interface IAccesoDatosUsuario
    {
        Task<Usuario> InsertarUsuario(Usuario usuario);

        Task<List<Usuario>> RetornarUsuarios();

        Task<Usuario> BuscarUsuario(string nombre);

        Task<Usuario> BuscarUsuarioLogin(DtoLogin dtoLogin);

        Task<int> ActualizarUsuario(Usuario usuario);

        Task<int> EliminarUsuario(string usuario);

        Task<bool> Transferir(Usuario remitente, Usuario destinatario, decimal valor);
    }
}
