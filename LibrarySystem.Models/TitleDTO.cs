using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class TitleDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter book name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter book description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter book writer")]
        public string Writer { get; set; }

        [Required(ErrorMessage ="Please enter book released year")]
        public int ReleaseYear { get; set; }

        public int? Isbn { get; set; }

        [Required(ErrorMessage = "Please enter book type")]
        public string Type { get; set; }

        public byte[] ImageContent { get; set; }

        public string ImageName { get; set; }

        [Required(ErrorMessage = "Please enter book publisher")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Please enter book section")]
        public string Section { get; set; }

        public virtual ICollection<ImageDto> TitleImages { get; set; }

        public List<string> ImageUrls { get; set; }

        public TitleDto()
        {
        }

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
