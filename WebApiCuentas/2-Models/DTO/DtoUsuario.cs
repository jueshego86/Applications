using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class DtoUsuario
    {
        public string Nombre { get; set; }

        public string Cuenta { get; set; }

        public bool Admin { get; set; }

        public decimal Balance { get; set; }

        public string Password { get; set; }
    }
}
