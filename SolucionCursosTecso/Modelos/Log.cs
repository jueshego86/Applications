using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Log
    {
        public int LogId { get; set; }

        public string Mensaje { get; set; }

        public int Tipo { get; set; }

        public DateTime Fecha { get; set; }
    }
}
