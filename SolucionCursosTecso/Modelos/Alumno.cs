using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Alumnos")]
    public class Alumno
    {
        public int AlumnoId { get; set; }

        [StringLength(10)]
        [Required]
        public string Cedula { get; set; }

        [StringLength(50)]
        [Required]
        public string NombreAlumno { get; set; }
    }
}
