using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos.IRepository
{
    public interface ITitleRepository
    {
        public Task<TitleDto> CreateBook(TitleDto titleDto);
        public Task<TitleDto> UpdateBook(int bookId, TitleDto titleDto);
        public Task<TitleDto> GetBook(int bookId);
        public void DeleteBook(int bookId);
        public Task<IEnumerable<TitleDto>> GetAllBooks();
        public Task<TitleDto> UniqueBook(string name, int bookId = 0);
    }
}
