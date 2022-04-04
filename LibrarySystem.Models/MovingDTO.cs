using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class MovingDTO
    {
        public DateTime? TimeTaken { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string Type { get; set; }
        [Key]
        public string Reader { get; set; }

        public string Condition { get; set; }
    }
}
