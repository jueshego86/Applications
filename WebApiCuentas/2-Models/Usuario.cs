using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string Cuenta { get; set; }

        public decimal Balance { get; set; }

        public string Password { get; set; }

        public bool Admin { get; set; }

        public Usuario()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
