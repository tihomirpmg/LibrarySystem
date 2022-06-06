﻿#nullable disable
namespace DataAcess.Data.Models
{
    using LibrarySystem.Data.Data;
    using LibrarySystem.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Title model class
    /// </summary>
    public class Title
    {
        /// <summary>
        /// Title Id property
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Title Name property
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Title Description property
        /// </summary>
        [Required]
        public string Description { get; set; }
        /// <summary>
        /// Title Writer property
        /// </summary>
        [Required]
        public string Writer { get; set; }
        /// <summary>
        /// Title ReleaseYear property
        /// </summary>
        [Required]
        public int ReleaseYear { get; set; }
        /// <summary>
        /// Title ISBN property
        /// </summary>
        public int? Isbn { get; set; }
        /// <summary>
        /// Title Type property
        /// </summary>
        [Required]
        public string Type { get; set; }
        /// <summary>
        /// Title ImageContent property
        /// </summary>
        public byte[] ImageContent { get; set; }
        /// <summary>
        /// Title ImageName property
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// Title Publisher property
        /// </summary>
        [Required]
        public string Publisher { get; set; }
        /// <summary>
        /// Title Section property
        /// </summary>
        [Required]
        public string Section { get; set; }
        
        public virtual ICollection<Images> TitleImages { get; set; }
        /// <summary>
        /// Title default constructor
        /// </summary>
        public Title()
        {
        }
        /// <summary>
        /// Title constructor
        /// </summary>
        /// <param name="titleDto">Parameter name</param>
        public Title(TitleDto titleDto)
        {
            this.Id = titleDto.Id;
            this.Name = titleDto.Name;
            this.Description = titleDto.Description;
            this.Writer = titleDto.Writer;
            this.ReleaseYear = titleDto.ReleaseYear;
            this.Isbn = titleDto.Isbn;
            this.Type = titleDto.Type;
            this.ImageContent = titleDto.ImageContent;
            this.ImageName = titleDto.ImageName;
            this.Publisher = titleDto.Publisher;
            this.Section = titleDto.Section;
        }
    }
}
