using AutoMapper;
using DataAcess.Data.Models;
using LibrarySystem.Bussines.Repos;
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

        public async Task<LibraryBookDto> CreateBookAsync(LibraryBookDto libraryBookDto)
        {
            LibraryBook libraryBook = _mapper.Map<LibraryBookDto, LibraryBook>(libraryBookDto);
            var addedLibraryBook = _db.LibraryBook.Add(libraryBook);
            await _db.SaveChangesAsync();
            return _mapper.Map<LibraryBook, LibraryBookDto>(addedLibraryBook.Entity);
        }

        public async Task<IEnumerable<LibraryBookDto>> GetAllBooksAsync()
        {
            try
            {
                IEnumerable<LibraryBookDto> libraryBookDtos=_mapper.Map<IEnumerable<LibraryBook>, IEnumerable< LibraryBookDto >> (_db.LibraryBook);
                return libraryBookDtos;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get all books.", ex);
            }
        }

        public async Task<LibraryBookDto> GetBookAsync(int bookId)
        {
            try
            {
                LibraryBookDto libraryBook = _mapper.Map<LibraryBook,LibraryBookDto>(
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

        public async Task<LibraryBookDto> GetUniqueBookAsync(string name, int bookId=0)
        {
            try
            {
                if (bookId == 0)
                {
                    LibraryBookDto libraryBook = _mapper.Map<LibraryBook, LibraryBookDto>(
                                        await _db.LibraryBook.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
                    return libraryBook;
                }
                else
                {
                    LibraryBookDto libraryBook = _mapper.Map<LibraryBook, LibraryBookDto>(
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

        public async Task<LibraryBookDto> UpdateBookAsync(int bookId, LibraryBookDto libraryBookDto)
        {
            try
            {
                if (bookId == libraryBookDto.Id)
                {
                    //valid
                    LibraryBook bookDetails = await _db.LibraryBook.FindAsync(bookId);
                    LibraryBook book = _mapper.Map<LibraryBookDto, LibraryBook>(libraryBookDto, bookDetails);
                    var updatedBook = _db.LibraryBook.Update(book);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<LibraryBook, LibraryBookDto>(updatedBook.Entity);
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
