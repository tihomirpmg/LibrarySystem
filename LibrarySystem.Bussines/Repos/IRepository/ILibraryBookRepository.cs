using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    /// <summary>
    /// Interface LibraryBookRepository class
    /// </summary>
    public interface ILibraryBookRepository
    {
        /// <summary>
        /// CreateBookAsync method
        /// </summary>
        /// <param name="libraryBookDto">LibraryBookDto parameter</param>
        /// <returns></returns>
        public LibraryBookDto CreateBook(LibraryBookDto libraryBookDto);
        /// <summary>
        /// UpdateBookAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <param name="libraryBookDto">LibraryBookDto parameter</param>
        /// <returns></returns>
        public LibraryBookDto UpdateBook(int bookId, LibraryBookDto libraryBookDto);
        /// <summary>
        /// GetBookAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public LibraryBookDto GetBook(int bookId);
        /// <summary>
        /// DeleteBookAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public int DeleteBook(int bookId);
        /// <summary>
        /// GetAllBooksAsync method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LibraryBookDto> GetAllBooks();
        /// <summary>
        /// GetUniqueBookAsync method
        /// </summary>
        /// <param name="name">String parameter</param>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public LibraryBookDto GetUniqueBook(string name, int bookId = 0);
    }
}
