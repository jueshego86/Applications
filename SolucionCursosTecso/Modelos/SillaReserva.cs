using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("SillasReserva")]
    public class SillaReserva
    {
        public int SillaReservaId { get; set; }

        public int SillaId { get; set; }

        public int ReservaAlumnoId { get; set; }

        public virtual Silla Silla { get; set; }

        public virtual ReservaAlumno ReservaAlumno { get; set; }
    }
}
