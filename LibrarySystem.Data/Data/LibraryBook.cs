namespace DataAcess.Data.Models
{
    using LibrarySystem.Models;
    using System.ComponentModel.DataAnnotations;
    /// <summary>
    /// LibraryBook model class
    /// </summary>
    public partial class LibraryBook
    {
        /// <summary>
        /// LibraryBook Id property
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// LibraryBook Name property
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// LibraryBook Condition property
        /// </summary>
        [Required]
        public string Condition { get; set; }
        /// <summary>
        /// LibraryBook Bearer property
        /// </summary>
        [Required]
        public string Bearer { get; set; }
        /// <summary>
        /// LibraryBook Stock property
        /// </summary>
        [Required]
        public string Stock { get; set; }

        public LibraryBook()
        {
        }

        public LibraryBook(LibraryBookDto libraryBookDto)
        {
            this.Id = libraryBookDto.Id;
            this.Name = libraryBookDto.Name;
            this.Condition = libraryBookDto.Condition;
            this.Bearer = libraryBookDto.Bearer;
            this.Stock = libraryBookDto.Stock;
        }
    }
}
