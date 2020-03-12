using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Cursos")]
    public class Curso
    {
        public int CursoId { get; set; }

        [StringLength(6)]
        [Required]
        [Index(IsUnique = true)]
        public string Codigo { get; set; }

        [StringLength(30)]
        [Required]
        public string NombreCurso { get; set; }

        [Required]
        public int Activo { get; set; }
    }
}
