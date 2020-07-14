using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2_Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int ClienteId { get; set; }

        //[Index(IsUnique = true)]
        [StringLength(12)]
        [Required(ErrorMessage = "Debe introducir un nro de cedula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debe introducir un nombre")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "El nombre debe tener una longitud entre 4 y 50 caracteres")]
        public string Nombre { get; set; }

        public bool Activo { get; set; }

        [Required]
        public string Sexo { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
