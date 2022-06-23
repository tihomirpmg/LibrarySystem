using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    /// <summary>
    /// TitleDto class
    /// </summary>
    public class TitleDto
    {
        /// <summary>
        /// TitleDto Id property
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// TitleDto Name property
        /// </summary>
        [Required(ErrorMessage = "Please enter book name")]
        public string Name { get; set; }
        /// <summary>
        /// TitleDto Description property
        /// </summary>
        [Required(ErrorMessage = "Please enter book description")]
        public string Description { get; set; }
        /// <summary>
        /// TitleDto Writer property
        /// </summary>
        [Required(ErrorMessage = "Please enter book writer")]
        public string Writer { get; set; }
        /// <summary>
        /// TitleDto ReleaseYear property
        /// </summary>
        [Required(ErrorMessage = "Please enter book released year")]
        public int ReleaseYear { get; set; }
        /// <summary>
        /// TitleDto ISBN property
        /// </summary>
        public int? Isbn { get; set; }
        /// <summary>
        /// TitleDto Type property
        /// </summary>
        [Required(ErrorMessage = "Please enter book type")]
        public string Type { get; set; }
        /// <summary>
        /// TitleDto ImageContent property
        /// </summary>
        public byte[] ImageContent { get; set; }
        /// <summary>
        /// TitleDto ImageName property
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// TitleDto Publisher property
        /// </summary>
        [Required(ErrorMessage = "Please enter book publisher")]
        public string Publisher { get; set; }
        /// <summary>
        /// TitleDto Section property
        /// </summary>
        [Required(ErrorMessage = "Please enter book section")]
        public string Section { get; set; }

        public virtual ICollection<ImageDto> TitleImages { get; set; }
        /// <summary>
        /// TitleDto ImageUrls property
        /// </summary>
        public List<string> ImageUrls { get; set; }
        /// <summary>
        /// TitleDto default constructor
        /// </summary>
        public TitleDto()
        {
        }
        /// <summary>
        /// TitleDto constructor
        /// </summary>
        /// <param name="id">Id property</param>
        /// <param name="name">Name property</param>
        /// <param name="description">Description property</param>
        /// <param name="writer">Writer property</param>
        /// <param name="releaseYear">ReleaseYear property</param>
        /// <param name="isbn">ISBN property</param>
        /// <param name="type">Type property</param>
        /// <param name="imageContent">ImageContent property</param>
        /// <param name="imageName">ImageName property</param>
        /// <param name="publisher">Publisher property</param>
        /// <param name="section">Section property</param>
        public TitleDto(
            int id,
            string name,
            string description,
            string writer,
            int releaseYear,
            int? isbn,
            string type,
            byte[] imageContent,
            string imageName,
            string publisher,
            string section)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Writer = writer;
            this.ReleaseYear = releaseYear;
            this.Isbn = isbn;
            this.Type = type;
            this.ImageContent = imageContent;
            this.ImageName = imageName;
            this.Publisher = publisher;
            this.Section = section;
        }
    }
}
