using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMvc.ViewModels
{
    public class CursoViewModel
    {
        public int CursoId { get; set; }

        [StringLength(6, MinimumLength = 4, ErrorMessage = "El codigo debe tener una longitud entre 4 y 6 caracteres")]
        [Required]
        [Display(Name = "Code")]
        public string Codigo { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe tener una longitud entre 3 y 30 caracteres")]
        [Required]
        [Display(Name = "Name")]
        public string NombreCurso { get; set; }

        [Required]
        [Display(Name = "Active")]
        public int Activo { get; set; }
    }
}