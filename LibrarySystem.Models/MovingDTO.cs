using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
