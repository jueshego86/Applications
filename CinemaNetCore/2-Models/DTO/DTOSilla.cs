using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Models.DTO
{
    public class DTOSilla
    {
        public int SillaId { get; set; }

        public string Codigo { get; set; }

        public DTOSala dtoSala { get; set; }
    }
}
