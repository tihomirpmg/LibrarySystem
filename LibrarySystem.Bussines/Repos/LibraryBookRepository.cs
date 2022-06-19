using DataAcess.Data.Models;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    /// <summary>
    /// LibraryBook Repository
    /// </summary>
    public class LibraryBookRepository : ILibraryBookRepository
    {
        private readonly LibrarySystemDbContext _db;
        public LibraryBookRepository(LibrarySystemDbContext db)
        {
            _db = db;
        }

        ///<inheritdoc/>
        public async Task<LibraryBookDto> CreateBookAsync(LibraryBookDto libraryBookDto)
        {
            LibraryBook libraryBook = Conversion.ConvertBook(libraryBookDto);
            var addedLibraryBook = _db.LibraryBook.Add(libraryBook);
            await _db.SaveChangesAsync();
            var result = Conversion.ConvertBook(addedLibraryBook.Entity);

            return result;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<LibraryBookDto>> GetAllBooksAsync()
        {
            try
            {
                IEnumerable<LibraryBook> books = _db.LibraryBook;
                IEnumerable<LibraryBookDto> result = books.Select(Conversion.ConvertBook);

                return result;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get all books.", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<LibraryBookDto> GetBookAsync(int bookId)
        {
            try
            {
                LibraryBook libraryBook = await _db.LibraryBook.FirstOrDefaultAsync(x => x.Id == bookId);
                LibraryBookDto result = Conversion.ConvertBook(libraryBook);
                return result;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get this book", ex);
            }
        }

        ///<inheritdoc/>
        public async Task DeleteBookAsync(int bookId)
        {
            var book = await _db.LibraryBook.FindAsync(bookId);
            if (book is null)
            {
                //throw error
            }
            _db.LibraryBook.Remove(book);
            await _db.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task<LibraryBookDto> GetUniqueBookAsync(string name, int bookId = 0)
        {
            try
            {
                if (bookId == 0)
                {
                    LibraryBook book = await _db.LibraryBook.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
                    LibraryBookDto result = Conversion.ConvertBook(book);

                    return result;
                }
                else
                {
                    LibraryBook book = await _db.LibraryBook.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()
                                        && x.Id == bookId);
                    LibraryBookDto result = Conversion.ConvertBook(book);

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Book is not unique.", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<LibraryBookDto> UpdateBookAsync(int bookId, LibraryBookDto libraryBookDto)
        {
            try
            {
                if (bookId == libraryBookDto.Id)
                {
                    LibraryBook book = await _db.LibraryBook.FindAsync(bookId);
                    LibraryBook convertedBook = Conversion.ConvertUpdate(book,libraryBookDto);
                    var updatedBook = _db.LibraryBook.Update(convertedBook);
                    await _db.SaveChangesAsync();
                    var result = Conversion.ConvertBook(updatedBook.Entity);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Book cannot be updated.", ex);
            }
        }
    }
}
