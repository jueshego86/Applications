using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2_Models
{
    [Table("Peliculas")]
    public class Pelicula
    {
        public int PeliculaId { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "El titulo debe tener una longitud entre 3 y 50 caracteres")]
        [Required]
        public string Titulo { get; set; }

        [Required]
        public DateTime Estreno { get; set; }

        [Required]
        public string RutaPoster { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
