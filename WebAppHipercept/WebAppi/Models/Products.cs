namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }
    }
}