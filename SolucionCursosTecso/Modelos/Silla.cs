using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Sillas")]
    public class Silla
    {
        public int SillaId { get; set; }

        [StringLength(3)]
        [Required]
        public string Codigo { get; set; }

        public virtual ICollection<SillaReserva> SillaReserva { get; set; }
    }
}
