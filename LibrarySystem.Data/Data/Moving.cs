﻿#nullable disable
namespace DataAcess.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Moving
    {
        public DateTime? TimeTaken { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string Type { get; set; }

        [Key]
        public string Reader { get; set; }

        public string Condition { get; set; }
    }
}
