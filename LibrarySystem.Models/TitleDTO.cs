using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class TitleDTO
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

        public virtual ICollection<ImagesDTO> TitleImages { get; set; }

        public List<string> ImageUrls { get; set; }
    }
}
