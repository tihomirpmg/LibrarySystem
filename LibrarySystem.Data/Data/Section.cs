#nullable disable
namespace DataAcess.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Section
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Book { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
