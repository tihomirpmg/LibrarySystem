﻿using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class SectionDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Books { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
