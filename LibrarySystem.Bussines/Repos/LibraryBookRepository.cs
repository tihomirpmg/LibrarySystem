using AutoMapper;
using DataAcess.Data.Models;
using LibrarySystem.Bussines.Repos.IRepository;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    public class LibraryBookRepository : ILibraryBookRepository
    {
        private readonly LibrarySystemDbContext _db;
        private readonly IMapper _mapper;
        public LibraryBookRepository(LibrarySystemDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<LibraryBookDTo> CreateBook(LibraryBookDTo libraryBookDTo)
        {
            LibraryBook libraryBook = _mapper.Map<LibraryBookDTo, LibraryBook>(libraryBookDTo);
            var addedLibraryBook = _db.LibraryBook.Add(libraryBook);
            await _db.SaveChangesAsync();
            return _mapper.Map<LibraryBook, LibraryBookDTo>(addedLibraryBook.Entity);
        }

        public async Task<IEnumerable<LibraryBookDTo>> GetAllBooks()
        {
            try
            {
                IEnumerable<LibraryBookDTo> libraryBookDTos=_mapper.Map<IEnumerable<LibraryBook>, IEnumerable< LibraryBookDTo >> (_db.LibraryBook);
                return libraryBookDTos;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get all books.", ex);
            }
        }

        public async Task<LibraryBookDTo> GetBook(int bookId)
        {
            try
            {
                LibraryBookDTo libraryBook = _mapper.Map<LibraryBook,LibraryBookDTo>(
                    await _db.LibraryBook.FirstOrDefaultAsync(x => x.Id == bookId));
                return libraryBook;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get this book", ex);
            }
        }
        public async void DeleteBook(int bookId)
        {
            var bookDetails = await _db.LibraryBook.FindAsync(bookId);
            if(bookDetails != null)
            {
                _db.LibraryBook.Remove(bookDetails);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<LibraryBookDTo> UniqueBook(string name, int bookId=0)
        {
            try
            {
                if (bookId == 0)
                {
                    LibraryBookDTo libraryBook = _mapper.Map<LibraryBook, LibraryBookDTo>(
                                        await _db.LibraryBook.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
                    return libraryBook;
                }
                else
                {
                    LibraryBookDTo libraryBook = _mapper.Map<LibraryBook, LibraryBookDTo>(
                                        await _db.LibraryBook.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()
                                        && x.Id != bookId));
                    return libraryBook;
                    
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Book is not unique.", ex);
            }
        }

        public async Task<LibraryBookDTo> UpdateBook(int bookId, LibraryBookDTo libraryBookDTo)
        {
            try
            {
                if (bookId == libraryBookDTo.Id)
                {
                    //valid
                    LibraryBook bookDetails = await _db.LibraryBook.FindAsync(bookId);
                    LibraryBook book = _mapper.Map<LibraryBookDTo, LibraryBook>(libraryBookDTo, bookDetails);
                    var updatedBook = _db.LibraryBook.Update(book);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<LibraryBook, LibraryBookDTo>(updatedBook.Entity);
                }
                else
                {
                    //invalid
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
