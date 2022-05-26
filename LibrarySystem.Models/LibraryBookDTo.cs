using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class LibraryBookDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter book name")]
        public string Name { get; set; }

        [Required]
        public string Condition { get; set; }

        [Required]
        public string Bearer { get; set; }

        [Required]
        public string Stock { get; set; }
    }
}
