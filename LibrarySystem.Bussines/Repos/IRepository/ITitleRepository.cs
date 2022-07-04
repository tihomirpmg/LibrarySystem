using LibrarySystem.Bussines.Repos.IRepository;
using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Repos
{
    /// <summary>
    /// Interface TitleRepository class
    /// </summary>
    public interface ITitleRepository : IBaseRepository<TitleDto>
    {
        /// <summary>
        /// Deletes book.
        /// </summary>
        /// <param name="bookId">the book ID</param>
        /// <returns>an empty result</returns>
        public Task DeleteAsync(int bookId);

        /// <summary>
        /// Check if the book is unique. 
        /// </summary>
        /// <param name="name">the book name</param>
        /// <param name="bookId">the book ID</param>
        /// <returns>the result</returns>
        public Task<TitleDto> GetUniqueAsync(string name, int bookId = 0);
    }
}
