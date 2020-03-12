namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LogInUsers")]
    public class LogInUsers
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime LoginDate { get; set; }
    }
}
