using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    public interface ITitleRepository
    {
        public Task<TitleDto> CreateBookAsync(TitleDto titleDto);
        public Task<TitleDto> UpdateBookAsync(int bookId, TitleDto titleDto);
        public Task<TitleDto> GetBookAsync(int bookId);
        public void DeleteBook(int bookId);
        public Task<IEnumerable<TitleDto>> GetAllBooksAsync();
        public Task<TitleDto> GetUniqueBookAsync(string name, int bookId = 0);
    }
}
