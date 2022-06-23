using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Repos
{
    /// <summary>
    /// Interface LibraryBookRepository class
    /// </summary>
    public interface ILibraryBookRepository
    {
        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="libraryBookDto">the book</param>
        /// <returns>the newly created book</returns>
        public Task<LibraryBookDto> CreateBookAsync(LibraryBookDto libraryBookDto);

        /// <summary>
        /// Updates book.
        /// </summary>
        /// <param name="bookId">the book ID</param>
        /// <param name="titleDto">>the book</param>
        /// <returns>the updated book</returns>
        public Task<LibraryBookDto> UpdateBookAsync(int bookId, LibraryBookDto libraryBookDto);

        /// <summary>
        /// Retrieves a book with specified ID.
        /// </summary>
        /// <param name="bookId">the book ID</param>
        /// <returns>the book</returns>
        public Task<LibraryBookDto> GetBookAsync(int bookId);

        /// <summary>
        /// Deletes book.
        /// </summary>
        /// <param name="bookId">the book ID</param>
        /// <returns>an empty result</returns>
        public Task DeleteBookAsync(int bookId);

        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>collection of books</returns>
        public Task<IEnumerable<LibraryBookDto>> GetAllBooksAsync();

        /// <summary>
        /// Check if the book is unique. 
        /// </summary>
        /// <param name="name">the book name</param>
        /// <param name="bookId">the book ID</param>
        /// <returns>the result</returns>
        public Task<LibraryBookDto> GetUniqueBookAsync(string name, int bookId = 0);
    }
}
