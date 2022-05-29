using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    public interface ILibraryBookRepository
    {
        public Task<LibraryBookDto> CreateBookAsync(LibraryBookDto libraryBookDto);
        public Task<LibraryBookDto> UpdateBookAsync(int bookId, LibraryBookDto libraryBookDto);
        public Task<LibraryBookDto> GetBookAsync(int bookId);
        public Task<int> DeleteBookAsync(int bookId);
        public Task<IEnumerable<LibraryBookDto>> GetAllBooksAsync();
        public Task<LibraryBookDto> GetUniqueBookAsync(string name, int bookId = 0);
    }
}
