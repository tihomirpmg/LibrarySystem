using DataAcess.Data.Models;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Repos
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
        public async Task<LibraryBookDTo> CreateAsync(LibraryBookDTo libraryBookDto, CancellationToken cancelletaionToken = default)
        {
            LibraryBook libraryBook = Conversion.ConvertBook(libraryBookDto);
            var addedLibraryBook = _db.LibraryBook.Add(libraryBook);
            await _db.SaveChangesAsync(cancelletaionToken);
            var result = Conversion.ConvertBook(addedLibraryBook.Entity);

            return result;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<LibraryBookDTo>> GetAllAsync(CancellationToken cancelletaionToken = default)
        {
            try
            {
                IEnumerable<LibraryBook> books = _db.LibraryBook;
                IEnumerable<LibraryBookDTo> result = books.Select(Conversion.ConvertBook);

                await _db.SaveChangesAsync(cancelletaionToken);
                return result;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get all books.", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<LibraryBookDTo> GetAsync(int bookId, CancellationToken cancelletaionToken = default)
        {
            try
            {
                LibraryBook libraryBook = await _db.LibraryBook.FirstOrDefaultAsync(x => x.Id == bookId, cancelletaionToken);
                LibraryBookDTo result = Conversion.ConvertBook(libraryBook);
                return result;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get this book", ex);
            }
        }

        ///<inheritdoc/>
        public async Task DeleteAsync(int bookId, CancellationToken cancelletaionToken = default)
        {
            var book = await _db.LibraryBook.FindAsync(bookId);
            if (book is null)
            {
                throw new RepositoryException("Can not update this book");
            }
            _db.LibraryBook.Remove(book);
            await _db.SaveChangesAsync(cancelletaionToken);
        }

        ///<inheritdoc/>
        public async Task<LibraryBookDTo> GetUniqueAsync(string name, int bookId = 0, CancellationToken cancelletaionToken = default)
        {
            try
            {
                if (bookId == 0)
                {
                    LibraryBook book = await _db.LibraryBook.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower(), cancelletaionToken);
                    LibraryBookDTo result = Conversion.ConvertBook(book);

                    return result;
                }
                else
                {
                    LibraryBook book = await _db.LibraryBook.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()
                                        && x.Id == bookId, cancelletaionToken);
                    LibraryBookDTo result = Conversion.ConvertBook(book);

                    return result;

                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Book is not unique.", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<LibraryBookDTo> UpdateAsync(int bookId, LibraryBookDTo libraryBookDto, CancellationToken cancelletaionToken = default)
        {
            try
            {
                if (bookId == libraryBookDto.Id)
                {
                    LibraryBook book = await _db.LibraryBook.FindAsync(bookId);
                    LibraryBook convertedBook = Conversion.ConvertUpdate(book, libraryBookDto);
                    var updatedBook = _db.LibraryBook.Update(convertedBook);
                    await _db.SaveChangesAsync(cancelletaionToken);
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
