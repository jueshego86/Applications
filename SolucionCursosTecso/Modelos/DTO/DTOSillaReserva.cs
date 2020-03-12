using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.DTO
{
    public class DTOSillaReserva
    {
        public int SillaReservaId { get; set; }

        public DTOSilla dtoSilla { get; set; }

        public DTOReservaAlumno dtoReserva { get; set; }
    }
}
