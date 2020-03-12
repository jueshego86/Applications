using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppMvc.ViewModels
{
    public class NotaViewModel
    {
        public int  NotaCursoId { get; set; }

        [Required(ErrorMessage = "Select a Student")]
        public int AlumnoId { get; set; }

        [Display(Name = "Student")]
        [MaxLength(50)]
        public string AlumnoNombre { get; set; }

        [Required(ErrorMessage = "Select a Course")]
        public int CursoId { get; set; }

        [Required]
        public int ReservaAlumnoId { get; set; }

        [Required]
        public int Calificacion { get; set; }

        public List<CursoViewModel> Cursos { get; set; }

        public CursoViewModel Curso { get; set; }

        public List<AlumnoViewModel> Alumnos { get; set; }

        public AlumnoViewModel Alumno { get; set; }

        public ReservaAlumnoViewModel ReservaAlumnoViewModel { get; set; }
    }
}