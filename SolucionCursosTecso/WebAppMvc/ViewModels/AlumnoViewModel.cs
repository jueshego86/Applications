using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMvc.ViewModels
{
    public class AlumnoViewModel
    {
        public int AlumnoId { get; set; }

        [StringLength(10, MinimumLength = 4, ErrorMessage = "El nombre debe tener una longitud entre 4 y 10 caracteres")]
        [Required]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [StringLength(50, MinimumLength = 6, ErrorMessage = "El nombre debe tener una longitud entre 6 y 50 caracteres")]
        [Required]
        [Display(Name = "Nombre")]
        public string NombreAlumno { get; set; }
    }
}