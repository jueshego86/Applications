namespace Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProductRequests")]
    public class ProductRequest
    {
        public int ProductRequestId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string UserName { get; set; }

        public virtual Product Product { get; set; }
    }
}

