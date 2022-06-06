using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    /// <summary>
    /// Interface TitleRepository class
    /// </summary>
    public interface ITitleRepository
    {
        /// <summary>
        /// CreateBookAsync method
        /// </summary>
        /// <param name="titleDto">TitleDto parameter</param>
        /// <returns></returns>
        public Task<TitleDto> CreateBookAsync(TitleDto titleDto);
        /// <summary>
        /// UpdateBookAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <param name="titleDto">>TitleDto parameter</param>
        /// <returns></returns>
        public Task<TitleDto> UpdateBookAsync(int bookId, TitleDto titleDto);
        /// <summary>
        /// GetBookAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public Task<TitleDto> GetBookAsync(int bookId);
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
        public Task<IEnumerable<TitleDto>> GetAllBooksAsync();
        /// <summary>
        /// GetUniqueBookAsync method
        /// </summary>
        /// <param name="name">String parameter</param>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public Task<TitleDto> GetUniqueBookAsync(string name, int bookId = 0);
    }
}
