using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos.IRepository
{
    public interface ITitleRepository
    {
        public Task<TitleDTO> CreateBook(TitleDTO titleDTO);
        public Task<TitleDTO> UpdateBook(int bookId, TitleDTO titleDTO);
        public Task<TitleDTO> GetBook(int bookId);
        public void DeleteBook(int bookId);
        public Task<IEnumerable<TitleDTO>> GetAllBooks();
        public Task<TitleDTO> UniqueBook(string name, int bookId = 0);
    }
}
