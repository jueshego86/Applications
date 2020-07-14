using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _2_Models;
using _2_Models.DTO;
using _3_Facade.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        private IFachadaCliente FachadaCliente;

        public ClienteController(IFachadaCliente fachadaCliente)
        {
            this.FachadaCliente = fachadaCliente;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
           return await this.FachadaCliente.ListarClientes();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Cliente cliente)
        {
            ValidationContext validationContext = new ValidationContext(cliente, null, null);
            List<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(cliente, validationContext, errors, true);

            if (errors.Count > 0)
            {
                return BadRequest(0);
            }

            await this.FachadaCliente.InsertarCliente(cliente);

            return Ok(cliente);
        }
        
        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]Cliente cliente)
        {
            ValidationContext validationContext = new ValidationContext(cliente, null, null);
            List<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(cliente, validationContext, errors, true);

            if (errors.Count > 0)
            {
                return BadRequest(0);
            }

            await this.FachadaCliente.ActualizarCliente(cliente);

            return Ok(cliente);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            if(id > 0)
            {
                await this.FachadaCliente.EliminarCliente(id);
            }
            else
            {

            }
        }
    }
}
