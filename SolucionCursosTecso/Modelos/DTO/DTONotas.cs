using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTO
{
    public class DTONotas
    {
        public int NotaCursoId { get; set; }

        public int ReservaAlumnoId { get; set; }

        public DTOCurso dtoCurso { get; set; }

        public DTOAlumno dtoAlumno { get; set; }

        public string Calificacion { get; set; }
    }
}
