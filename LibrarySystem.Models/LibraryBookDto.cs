using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    /// <summary>
    /// LibraryBookDto class
    /// </summary>
    public class LibraryBookDto
    {
        /// <summary>
        /// LibraryBookDto Id property
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// LibraryBookDto Name property
        /// </summary>
        [Required(ErrorMessage = "Please enter book name")]
        public string Name { get; set; }

        /// <summary>
        /// LibraryBookDto Condition property
        /// </summary>
        [Required]
        public string Condition { get; set; }

        /// <summary>
        /// LibraryBookDto Bearer property
        /// </summary>
        [Required]
        public string Bearer { get; set; }

        /// <summary>
        /// LibraryBookDto Stock property
        /// </summary>
        [Required]
        public string Stock { get; set; }
    }
}