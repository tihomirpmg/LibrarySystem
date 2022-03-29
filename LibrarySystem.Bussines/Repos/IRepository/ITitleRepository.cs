using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos.IRepository
{
    public interface ITitleRepository
    {
        public Task<TitleDTO> CreateBook(TitleDTO titleDTO);
        public Task<TitleDTO> UpdateBook(int bookId, TitleDTO titleDTO);
        public Task<TitleDTO> GetBook(int bookId);
        public Task<int> DeleteBook(int bookId);
        public Task<IEnumerable<TitleDTO>> GetAllBooks();
        public Task<TitleDTO> IsBookUnique(string name, int bookId = 0);
    }
}
