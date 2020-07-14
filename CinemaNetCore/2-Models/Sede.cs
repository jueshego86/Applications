using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2_Models
{
    [Table("Sedes")]
    public class Sede
    {
        public int SedeId { get; set; }

        [StringLength(30)]
        [Required]
        public string NombreSede { get; set; }

        public virtual ICollection<Sala> Salas { get; set; }
    }
}
