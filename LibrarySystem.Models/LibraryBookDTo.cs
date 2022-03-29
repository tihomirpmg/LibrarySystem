using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class LibraryBookDTo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter book name")]
        public string Name { get; set; }
        [Required]
        public string Condition { get; set; }
        [Required]
        public string Bearer { get; set; }
        [Required]
        public string Stock { get; set; }
    }
}
