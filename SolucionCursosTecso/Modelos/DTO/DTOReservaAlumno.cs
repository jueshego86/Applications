using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTO
{
    public class DTOReservaAlumno
    {
        public int? ReservaId { get; set; }

        public DTOCurso dtoCurso { get; set; }

        public DTOAlumno dtoAlumno { get; set; }
    }
}
