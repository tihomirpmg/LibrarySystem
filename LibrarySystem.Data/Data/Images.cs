using DataAcess.Data.Models;
using LibrarySystem.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Data.Data
{
    public class Images
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string BookImageUrl { get; set; }

        [ForeignKey("BookId")]
        public virtual Title Title { get; set; }

        public Images()
        {
        }

        public Images(ImageDto imagesDto)
        {
            this.Id = imagesDto.Id;
            this.BookId = imagesDto.BookId;
            this.BookImageUrl = imagesDto.BookImageUrl;
        }
    }
}
