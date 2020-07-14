using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Models.DTO
{
    public class DTOSillaReserva
    {
        public int SillaReservaId { get; set; }

        public DTOSilla dtoSilla { get; set; }

        public DTOReserva dtoReserva { get; set; }
    }
}
