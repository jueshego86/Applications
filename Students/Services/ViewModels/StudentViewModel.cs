namespace Services.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Career { get; set; }
    }
}
