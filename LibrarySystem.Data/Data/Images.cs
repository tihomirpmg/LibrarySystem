using DataAcess.Data.Models;
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
    }
}
