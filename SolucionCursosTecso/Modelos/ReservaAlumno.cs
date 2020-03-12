using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("ReservasAlumnos")]
    public class ReservaAlumno
    {
        public int ReservaAlumnoId { get; set; }

        [Required]
        public int CursoId { get; set; }

        [Required]
        public int AlumnoId { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Alumno Alumno { get; set; }

        //public virtual ICollection<SillaReserva> SillaReserva { get; set; }
    }
}