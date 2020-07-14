using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Models.DTO
{
    public class DTOReserva
    {
        public int? ReservaId { get; set; }

        public DTOCliente dtoCliente { get; set; }

        public DTOPelicula dtoPelicula { get; set; }
    }
}
