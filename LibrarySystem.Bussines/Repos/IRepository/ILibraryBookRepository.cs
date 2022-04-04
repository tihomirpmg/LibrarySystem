using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos.IRepository
{
    public interface ILibraryBookRepository
    {
        public Task<LibraryBookDTo> CreateBook(LibraryBookDTo libraryBookDTo);
        public Task<LibraryBookDTo> UpdateBook(int bookId, LibraryBookDTo libraryBookDTo);
        public Task<LibraryBookDTo> GetBook(int bookId);
        public Task<int> DeleteBook(int bookId);
        public Task<IEnumerable<LibraryBookDTo>> GetAllBooks();
        public Task<LibraryBookDTo> IsBookUnique(string name, int bookId=0);

    }
}
