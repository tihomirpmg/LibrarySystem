namespace DataAcess.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class LibraryBook
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Condition { get; set; }
        [Required]
        public string Bearer { get; set; }
        [Required]
        public string Stock { get; set; }
    }
}
