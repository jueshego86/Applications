using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("NotasCursos")]
    public class NotaCurso
    {
        public int NotaCursoId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int ReservaAlumnoId { get; set; }

        [Required]
        public int Calificacion { get; set; }

        public virtual ReservaAlumno ReservaAlumno { get; set; }
    }
}
