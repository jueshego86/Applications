using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using _2_Models;
using _3_Facade.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _1_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Pelicula")]
    public class PeliculaController : Controller
    {
        private IFachadaPelicula FachadaPelicula;

        public PeliculaController(IFachadaPelicula fachadaPelicula)
        {
            this.FachadaPelicula = fachadaPelicula;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Pelicula> peliculas = await this.FachadaPelicula.ListarPeliculas();

            return Ok(peliculas);
        }

        [HttpGet("{peliculaId}")]
        public async Task<ActionResult> Get(int peliculaId)
        {
            Pelicula pelicula = await this.FachadaPelicula.ObtenerPelicula(peliculaId);

            return Ok(pelicula);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Pelicula pelicula)
        {
            ValidationContext validationContext = new ValidationContext(pelicula, null, null);
            List<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(pelicula, validationContext, errors, true);

            if (errors.Count > 0)
            {
                return BadRequest(0);
            }

            await this.FachadaPelicula.InsertarPelicula(pelicula);

            return Ok(pelicula);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            await this.FachadaPelicula.EliminarPelicula(id);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody]Pelicula pelicula)
        {
            ValidationContext validationContext = new ValidationContext(pelicula, null, null);
            List<ValidationResult> errors = new List<ValidationResult>();
            Validator.TryValidateObject(pelicula, validationContext, errors, true);

            if (errors.Count > 0)
            {
                return BadRequest(0);
            }

            await this.FachadaPelicula.ActualizarPelicula(pelicula);

            return Ok(pelicula);
        }
    }
}