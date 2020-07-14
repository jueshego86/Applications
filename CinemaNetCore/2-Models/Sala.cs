using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2_Models
{
    [Table("Salas")]
    public class Sala
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe introducir un codigo")]
        [StringLength(2, MinimumLength = 4, ErrorMessage = "El codigo debe tener una longitud entre 4 y 50 caracteres")]
        public string CodigoSala { get; set; }

        [Required]
        public int Capacidad { get; set; }

        [Required]
        public int SedeId { get; set; }

        public virtual Sede Sede { get; set; }

        public virtual ICollection<Silla> Silla { get; set; }
    }
}
