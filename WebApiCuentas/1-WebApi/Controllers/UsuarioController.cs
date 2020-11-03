using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Models;
using Models.DTO;
using Facade.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    /// <summary>
    /// controlador para el api de Usuarios
    /// </summary>
    [Produces("application/json")]
    [Route("api/Usuarios")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : Controller
    {
        #region private members
        /// <summary>
        /// propiedad a inyectar la fachada de la entidad
        /// </summary>
        private IFachadaUsuario fachadaUsuario;
        #endregion

        #region public methods
        /// <summary>
        /// constructor de la clase
        /// </summary>
        /// <param name="fachadaUsuario">inyeccion de la fachada de la entidad</param>
        public UsuarioController(IFachadaUsuario fachadaUsuario)
        {
            this.fachadaUsuario = fachadaUsuario;
        }

        #region admin
        /// <summary>
        /// Accion para la recuperacion de todos los usuarios (seccion para el rol Admin)
        /// </summary>
        /// <returns>resultado de la accion con todos los usuarios</returns>
        // GET: api/usuarios/admin
        [HttpGet("admin")]
        public async Task<ActionResult> Get()
        {
            //bool isAdmin = User.Claims.ToList().FirstOrDefault(c => c.Type.ToString().Equals(ClaimTypes.Role)).Value == "Admin" ? true : false;

            //if (User.IsInRole("Admin"))
            //{
            return Ok(await this.fachadaUsuario.ListarUsuarios());
            //}

            //return StatusCode(401);
        }

        /// <summary>
        /// Accion para la insercion de usuarios (seccion para el rol Admin)
        /// </summary>
        /// <returns>resultado de la accion con los datos del nuevo usuario</returns>
        // POST: api/Usuario
        [HttpPost("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Post([FromBody]DtoUsuario dtoUsuario)
        {
            if (dtoUsuario == null)
            {
                return BadRequest(new
                {
                    mensaje = "datos incompletos"
                });
            }

            ValidationContext validationContext = new ValidationContext(dtoUsuario, null, null);
            List<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(dtoUsuario, validationContext, errors, true);

            if (errors.Count > 0)
            {
                return BadRequest(new
                {
                    mensaje = "datos incompletos"
                });
            }

            Usuario usuario = new Usuario
            {
                Nombre = dtoUsuario.Nombre,
                Cuenta = dtoUsuario.Cuenta,
                Admin = dtoUsuario.Admin,
                Balance = dtoUsuario.Balance,
                Password = dtoUsuario.Password
            };

            await this.fachadaUsuario.InsertarUsuario(usuario);

            return Ok(usuario);
        }

        /// <summary>
        /// Accion para la actualizacion de usuarios (seccion para el rol Admin)
        /// </summary>
        /// <returns>resultado de la accion con los datos del usuario actualizado</returns>
        // PUT: api/usuarios/admin/jose
        [HttpPut("admin/{nombre}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put([FromRoute]string nombre, [FromBody]Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest(new
                {
                    mensaje = "datos incompletos"
                });
            }

            ValidationContext validationContext = new ValidationContext(usuario, null, null);
            List<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(usuario, validationContext, errors, true);

            if (errors.Count > 0)
            {
                return BadRequest(new
                {
                    mensaje = "datos incompletos"
                });
            }

            Usuario usuarioEditar = await this.fachadaUsuario.BuscarUsuario(nombre);

            if (usuarioEditar == null)
            {
                return BadRequest(new
                {
                    mensaje = $"el usuario con nombre {nombre} no existe"
                });
            }

            usuarioEditar.Nombre = usuario.Nombre;
            usuarioEditar.Admin = usuario.Admin;
            usuarioEditar.Cuenta = usuario.Cuenta;
            usuarioEditar.Password = usuario.Password;

            bool result = await this.fachadaUsuario.ActualizarUsuario(usuarioEditar);

            if (result)
            {
                return Ok(usuarioEditar);
            }
            else
            {
                return BadRequest(new
                {
                    mensaje = "el usuario no fue actualizado"
                });
            }
        }

        /// <summary>
        /// Accion para la eliminacion de un usuario (seccion para el rol Admin)
        /// </summary>
        /// <returns>resultado de la accion, devuelve 1 si el usuario fue eliminado</returns>
        // DELETE: api/usuarios/admin/jose
        [HttpDelete("admin/{nombre}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete([FromRoute]string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                return BadRequest(0);
            }

            bool result = await this.fachadaUsuario.EliminarUsuario(nombre);

            if (result)
            {
                return Ok(1);
            }

            return BadRequest(0);
        }
        #endregion

        #region user
        /// <summary>
        /// Accion para la recuperacion de un usuario(seccion para el rol User)
        /// </summary>
        /// <returns>resultado de la accion con los datos del usuario encontrado para el nombre dado</returns>
        // GET: api/Usuarios/user
        [HttpGet("user")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> GetUser()
        {
            Usuario usuario = await this.fachadaUsuario.BuscarUsuario(User.Identity.Name);

            if (usuario != null)
            {
                return Ok(usuario);
            }

            return BadRequest(new
            {
                mensaje = "remitente no existe"
            });
        }

        /// <summary>
        /// Accion para transferir de una cuanta de usuario a otra cuenta de usuario (seccion para el rol User)
        /// </summary>
        /// <returns>resultado de la accion, devuelve true si la operacion fue realizada</returns>
        // PUT: api/usuarios/user/pedro
        [HttpPut("user/{nombre}/{valor}")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> Put([FromRoute]string nombre, [FromRoute]decimal valor)
        {
            if (valor > 0)
            {
                Usuario usuarioDestino = await this.fachadaUsuario.BuscarUsuario(nombre);

                if(usuarioDestino == null)
                {
                    return BadRequest(new
                    {
                        mensaje = "destinatario no existe"
                    });
                }

                Usuario usuarioRemitente = await this.fachadaUsuario.BuscarUsuario(User.Identity.Name);

                if (valor > usuarioRemitente.Balance)
                {
                    return BadRequest(new
                    {
                        mensaje = "balance insuficiente"
                    });
                }

                bool response = await this.fachadaUsuario.Transferir(usuarioRemitente, usuarioDestino, valor);

                if (response)
                {
                    return Ok($"Nuevo saldo: €{usuarioRemitente.Balance} ");
                }
                else
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest(new
                {
                    mensaje = "el valor debe ser mayor a cero (0)"
                });
            }
        }
        #endregion
        #endregion
    }
}