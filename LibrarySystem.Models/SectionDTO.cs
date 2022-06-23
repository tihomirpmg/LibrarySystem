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
        public string Book { get; set; }
        /// <summary>
        /// SectionDto Description property
        /// </summary>
        [Required]
        public string Description { get; set; }

        public SectionDto()
        {
        }

        public SectionDto(
            int id,
            string name,
            string book,
            string description)
        {
            this.Id = id;
            this.Name = name;
            this.Book = book;
            this.Description = description;
        }
    }
}
