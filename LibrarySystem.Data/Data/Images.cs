using DataAcess.Data.Models;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Data.Data
{
    /// <summary>
    /// Images model class
    /// </summary>
    public class Images
    {
        /// <summary>
        /// Images Id property
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Images BookId property
        /// </summary>
        public int BookId { get; set; }
        /// <summary>
        /// Images BookImageUrl property
        /// </summary>
        public string BookImageUrl { get; set; }
        /// <summary>
        /// Images virtual Title property
        /// </summary>
        [ForeignKey("BookId")]
        public virtual Title Title { get; set; }
        /// <summary>
        /// Images default constructor
        /// </summary>
        public Images()
        {
        }
        /// <summary>
        /// Images constructor
        /// </summary>
        /// <param name="imagesDto">Parameter</param>
        public Images(ImageDto imagesDto)
        {
            this.Id = imagesDto.Id;
            this.BookId = imagesDto.BookId;
            this.BookImageUrl = imagesDto.BookImageUrl;
        }
    }
}
