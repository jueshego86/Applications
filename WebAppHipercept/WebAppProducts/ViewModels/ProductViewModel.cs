using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppProducts.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        public string Name { get; set; }

        [Required]
        [Display(Name = "Stock")]
        public int Stock { get; set; }
    }
}