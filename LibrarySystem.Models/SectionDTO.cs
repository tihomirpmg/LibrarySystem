using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    /// <summary>
    /// SectionDto class
    /// </summary>
    public class SectionDto
    {
        /// <summary>
        /// SectionDto Id property
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// SectionDto Name property
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// SectionDto Books property
        /// </summary>
        [Required]
        public string Books { get; set; }
        /// <summary>
        /// SectionDto Description property
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}
