using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Models.DTO
{
    public class DTOSala
    {
        public int SalaId { get; set; }

        public string CodigoSala { get; set; }

        public int Capacidad { get; set; }

        public DTOSede dtoSede { get; set; }
    }
}
