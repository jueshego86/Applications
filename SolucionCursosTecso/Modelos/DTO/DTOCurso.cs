using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTO
{
    public class DTOCurso
    {
        public int CursoId { get; set; }

        public string Codigo { get; set; }

        public string NombreCurso { get; set; }

        public int Activo { get; set; }
    }
}
