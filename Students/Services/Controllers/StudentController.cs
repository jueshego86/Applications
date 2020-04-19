namespace Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Facade.Contracts;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Model;
    using Services.ViewModels;

    [Produces("application/json")]
    [Route("api/Student")]
    [EnableCors("MyPolicy")]
    public class StudentController : Controller
    {
        private IStudentFacade FacadeStudent;

        public StudentController(IStudentFacade facade)
        {
            this.FacadeStudent = facade;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await this.FacadeStudent.GetAll());
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
            
        }

        // GET: api/Student/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                Student student = await this.FacadeStudent.GetStudent(id);

                if(student == null)
                {
                    return BadRequest();
                }

                return Ok(student);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
            
        }

        // POST: api/Student
        [HttpPost("insert")]
        //[ValidateAntiForgeryToken]
        //[EnableCors("AllowMyOrigin")]
        public async Task<ActionResult> Insert([FromBody]StudentViewModel studentViewModel)
        {
            try
            {
                ValidationContext validationContext = new ValidationContext(studentViewModel, null, null);
                List<ValidationResult> errors = new List<ValidationResult>();
                Validator.TryValidateObject(studentViewModel, validationContext, errors, true);

                if (errors.Count > 0)
                {
                    return BadRequest(0);
                }

                Student student = new Student
                {
                    UserName = studentViewModel.UserName,
                    FirstName = studentViewModel.FirstName,
                    LastName = studentViewModel.LastName,
                    Age = studentViewModel.Age,
                    Career = studentViewModel.Career
                };

                return Ok(await this.FacadeStudent.Insert(student));
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return StatusCode(500);
            }
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody]StudentViewModel studentViewModel)
        {
            try { 
                ValidationContext validationContext = new ValidationContext(studentViewModel, null, null);
                List<ValidationResult> errors = new List<ValidationResult>();
                Validator.TryValidateObject(studentViewModel, validationContext, errors, true);

                if (errors.Count > 0)
                {
                    return BadRequest(0);
                }

                Student student = new Student
                {
                    Id = studentViewModel.Id,
                    UserName = studentViewModel.UserName,
                    FirstName = studentViewModel.FirstName,
                    LastName = studentViewModel.LastName,
                    Age = studentViewModel.Age,
                    Career = studentViewModel.Career
                };

                await this.FacadeStudent.Update(student);

                return Ok();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return StatusCode(500);
            }
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await this.FacadeStudent.Delete(id);

                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
