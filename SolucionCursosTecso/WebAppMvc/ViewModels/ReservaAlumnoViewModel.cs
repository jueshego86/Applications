using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMvc.ViewModels
{
    public class ReservaAlumnoViewModel
    {
        [Required(ErrorMessage = "Debe agregar un Alumno")]
        public int AlumnoId { get; set; }

        [Display(Name = "Alumno")]
        [MaxLength(50)]
        public string AlumnoNombre { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Curso")]
        public int CursoId { get; set; }

        public List<CursoViewModel> Cursos { get; set; }

        public CursoViewModel Curso { get; set; }

        public List<SillaViewModel> Sillas { get; set; }

        public SillaViewModel Silla { get; set; }
    }
}