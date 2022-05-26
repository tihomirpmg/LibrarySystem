using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    public interface ILibraryBookRepository
    {
        public Task<LibraryBookDto> CreateBook(LibraryBookDto libraryBookDto);
        public Task<LibraryBookDto> UpdateBook(int bookId, LibraryBookDto libraryBookDto);
        public Task<LibraryBookDto> GetBook(int bookId);
        public void DeleteBook(int bookId);
        public Task<IEnumerable<LibraryBookDto>> GetAllBooks();
        public Task<LibraryBookDto> UniqueBook(string name, int bookId=0);

    }
}
