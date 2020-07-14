using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Models.DTO
{
    public class DTOCliente
    {
        public int ClienteId { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public string Sexo { get; set; }
    }
}
