#nullable disable
namespace DataAcess.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// Moving model class
    /// </summary>
    public partial class Moving
    {
        /// <summary>
        /// Moving TimeTaken property
        /// </summary>
        public DateTime? TimeTaken { get; set; }
        /// <summary>
        /// Moving ReturnDate property
        /// </summary>
        public DateTime? ReturnDate { get; set; }
        /// <summary>
        /// Moving Type property
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Moving Reader property
        /// </summary>
        [Key]
        public string Reader { get; set; }
        /// <summary>
        /// Moving Condition property
        /// </summary>
        public string Condition { get; set; }
    }
}
