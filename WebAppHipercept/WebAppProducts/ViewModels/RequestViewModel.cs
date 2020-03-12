namespace WebAppProducts.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RequestViewModel
    {
        public int RequestId { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public List<ProductViewModel> Products { get; set; }

        public int Stock { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        public string UserName { get; set; }
    }
}