using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Models;
using Models.DTO;
using Facade.Contracts;
using Microsoft.AspNetCore.Mvc;
using WebApi.Servicios.Contrats;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    /// <summary>
    /// controlador para el api de autenticacion de usuarios
    /// </summary>
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        /// <summary>
        /// propiedad a inyectar la fachada de la entidad
        /// </summary>
        private IFachadaUsuario fachadaUsuario;

        /// <summary>
        /// propiedad a inyectar la construccion de tokens
        /// </summary>
        private ITokenBuilder tokenBuilder;

        /// <summary>
        /// constructor de la clase
        /// </summary>
        /// <param name="fachadaUsuario">inyeccion de la fachada de la entidad</param>
        /// <param name="tokenBuilder">inyeccion del servicio de construccion de tokens</param>
        public LoginController(IFachadaUsuario fachadaUsuario, ITokenBuilder tokenBuilder)
        {
            this.fachadaUsuario = fachadaUsuario;
            this.tokenBuilder = tokenBuilder;
        }

        /// <summary>
        /// el metodo para la autenticacion y obtencion del token
        /// </summary>
        /// <param name="dtoLogin">el objeto con la informacion del usuario para inicio de sesion</param>
        /// <returns>resultado de la accion, devuelve el token de autorizacion</returns>
        [HttpPost("iniciar")]
        public async Task<IActionResult> Post([FromBody]DtoLogin dtoLogin)
        {
            ValidationContext validationContext = new ValidationContext(dtoLogin, null, null);
            List<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(dtoLogin, validationContext, errors, true);

            if (errors.Count > 0)
            {
                return BadRequest(0);
            }

            Usuario usuario = await this.fachadaUsuario.BuscarUsuarioLogin(dtoLogin);

            if (usuario == null)
            {
                return StatusCode(401);
            }

            return Ok(this.tokenBuilder.BuildToken(usuario));
        }
    }
}