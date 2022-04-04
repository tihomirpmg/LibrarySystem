namespace DataAcess.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Roles { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Names { get; set; }

    }
}
