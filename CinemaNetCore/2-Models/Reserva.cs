using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2_Models
{
    [Table("Reservas")]
    public class Reserva
    {
        public int ReservaId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int PeliculaId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Pelicula Pelicula { get; set; }

        public virtual ICollection<SillaReserva> SillaReserva { get; set; }
    }
}
