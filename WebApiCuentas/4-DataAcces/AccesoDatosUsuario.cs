using Models;
using Models.DTO;
using DataAcces.Contrats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAcces
{
    /// <summary>
    /// clase para el acceso a datos de la entidad Usuario
    /// </summary>
    public class AccesoDatosUsuario : IAccesoDatosUsuario
    {
        /// <summary>
        /// propiedad a inyectar el contexto de la bd
        /// </summary>
        private Context contexto;

        /// <summary>
        /// constructor de la clase
        /// </summary>
        /// <param name="contexto"></param>
        public AccesoDatosUsuario(Context contexto)
        {
            this.contexto = contexto;
        }

        /// <summary>
        /// Actualiza un Usuario
        /// </summary>
        /// <param name="usuario">el objeto con los datos del usuario a actualizar</param>
        /// <returns>1 en caso de actualizar con exito</returns>
        public async Task<int> ActualizarUsuario(Usuario usuario)
        {
            this.contexto.Entry(usuario).State = EntityState.Modified;
            return await contexto.SaveChangesAsync();
        }

        /// <summary>
        /// Busca un Usuario por su nombre
        /// </summary>
        /// <param name="nombre">nombre del usuario a buscar</param>
        /// <returns>el objeto con los datos del usuario encontrado</returns>
        public async Task<Usuario> BuscarUsuario(string nombre)
        {
            return await this.contexto.Usuarios.FirstOrDefaultAsync(u => u.Nombre == nombre);
        }

        /// <summary>
        /// Busca un usuario por nombre y password
        /// </summary>
        /// <param name="dtoLogin">objeto con nombre de usuario y password</param>
        /// <returns>el usuario con las credenciales dadas</returns>
        public async Task<Usuario> BuscarUsuarioLogin(DtoLogin dtoLogin)
        {
            return await this.contexto.Usuarios.FirstOrDefaultAsync(u => u.Nombre == dtoLogin.Nombre && u.Password == dtoLogin.Password);
        }

        /// <summary>
        /// Elimina un Usuario
        /// </summary>
        /// <param name="nombre">el nombre del usuario a eliminar</param>
        /// <returns>retorna 1 si elimino con exito, 0 si hubo errores</returns>
        public async Task<int> EliminarUsuario(string nombre)
        {
            Usuario usuario = await BuscarUsuario(nombre);

            if (usuario != null)
            {
                try
                {
                    this.contexto.Usuarios.Remove(usuario);
                    return await this.contexto.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

            return 0;
        }

        /// <summary>
        /// inserta un usuario en la tabla de usuarios
        /// </summary>
        /// <param name="usuario">el objeto con los datos del usuario a insertar</param>
        /// <returns>el objeto usuario insertado</returns>
        public async Task<Usuario> InsertarUsuario(Usuario usuario)
        {
            try
            {
                this.contexto.Usuarios.Add(usuario);
                await this.contexto.SaveChangesAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// Retornar todos los Usuarios
        /// </summary>
        /// <returns>la lista de usuarios</returns>
        public async Task<List<Usuario>> RetornarUsuarios()
        {
            return await this.contexto.Usuarios.ToListAsync();
        }

        /// <summary>
        /// transfiere balance de un usuario a otro
        /// </summary>
        /// <param name="remitente">entidad usuario remitente</param>
        /// <param name="destinatario">entidad usuario destino</param>
        /// <param name="valor">valor a transferir</param>
        /// <returns>booleano que indica si se realizo la transferencia con exito</returns>
        public async Task<bool> Transferir(Usuario remitente, Usuario destinatario, decimal valor)
        {
            try
            {
                remitente.Balance -= valor;

                destinatario.Balance += valor;

                await this.contexto.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
