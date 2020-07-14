using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2_Models
{
    [Table("Sillas")]
    public class Silla
    {
        public int SillaId { get; set; }

        [StringLength(3)]
        [Required]
        public string Codigo { get; set; }

        [Required]
        public int SalaId { get; set; }

        public virtual Sala Sala { get; set; }

        public virtual ICollection<SillaReserva> SillaReserva { get; set; }
    }
}
