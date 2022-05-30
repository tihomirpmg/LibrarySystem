#nullable disable
namespace DataAcess.Data.Models
{
    using LibrarySystem.Data.Data;
    using LibrarySystem.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Title
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Writer { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        public int? Isbn { get; set; }

        [Required]
        public string Type { get; set; }
        
        public byte[] ImageContent { get; set; }

        public string ImageName { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Section { get; set; }

        public virtual ICollection<Images> TitleImages { get; set; }

        public Title()
        {
        }

        public Title(TitleDto titleDto)
        {
            this.Id = titleDto.Id;
            this.Name = titleDto.Name;
            this.Description = titleDto.Description;
            this.Writer = titleDto.Writer;
            this.ReleaseYear = titleDto.ReleaseYear;
            this.Isbn = titleDto.Isbn;
            this.Type = titleDto.Type;
            this.ImageContent = titleDto.ImageContent;
            this.ImageName = titleDto.ImageName;
            this.Publisher = titleDto.Publisher;
            this.Section = titleDto.Section;
        }
    }
}
