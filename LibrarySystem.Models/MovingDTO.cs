using System;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    /// <summary>
    /// MovingDto class
    /// </summary>
    public class MovingDto
    {
        /// <summary>
        /// MovingDto TimeTaken property
        /// </summary>
        public DateTime? TimeTaken { get; set; }
        /// <summary>
        /// MovingDto ReturnDate property
        /// </summary>
        public DateTime? ReturnDate { get; set; }
        /// <summary>
        /// MovingDto Type property
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// MovingDto Reader property
        /// </summary>
        [Key]
        public string Reader { get; set; }
        /// <summary>
        /// MovingDto Condition property
        /// </summary>
        public string Condition { get; set; }
    }
}
