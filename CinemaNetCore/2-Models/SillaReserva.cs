using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2_Models
{
    [Table("SillasReserva")]
    public class SillaReserva
    {
        public int SillaReservaId { get; set; }

        public int SillaId { get; set; }

        public int ReservaId { get; set; }

        public virtual Silla Silla { get; set; }

        public virtual Reserva Reserva { get; set; }
    }
}
