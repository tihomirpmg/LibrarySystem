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
        public Task<LibraryBookDto> CreateBookAsync(LibraryBookDto libraryBookDto);
        /// <summary>
        /// UpdateBookAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <param name="libraryBookDto">LibraryBookDto parameter</param>
        /// <returns></returns>
        public Task<LibraryBookDto> UpdateBookAsync(int bookId, LibraryBookDto libraryBookDto);
        /// <summary>
        /// GetBookAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public Task<LibraryBookDto> GetBookAsync(int bookId);
        /// <summary>
        /// DeleteBookAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public Task<int> DeleteBookAsync(int bookId);
        /// <summary>
        /// GetAllBooksAsync method
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<LibraryBookDto>> GetAllBooksAsync();
        /// <summary>
        /// GetUniqueBookAsync method
        /// </summary>
        /// <param name="name">String parameter</param>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public Task<LibraryBookDto> GetUniqueBookAsync(string name, int bookId = 0);
    }
}
