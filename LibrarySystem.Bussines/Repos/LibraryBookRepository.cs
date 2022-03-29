using AutoMapper;
using DataAcess.Data.Models;
using LibrarySystem.Bussines.Repos.IRepository;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //libraryBook.CreatedDate = DateTime.Now;
            //libraryBook.CreatedBy = "";
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
            catch(Exception ex)
            {
                return null;
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
                return null;
            }
        }
        public async Task<int> DeleteBook(int bookId)
        {
            var bookDetails = await _db.LibraryBook.FindAsync(bookId);
            if(bookDetails != null)
            {
                _db.LibraryBook.Remove(bookDetails);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<LibraryBookDTo> IsBookUnique(string name, int bookId=0)
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
                                        && x.Id!=bookId));
                    return libraryBook;
                }
            }
            catch (Exception ex)
            {
                return null;
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
                    //book.UpdatedBy = "";
                    //book.UpdatedDate = DateTime.Now;
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
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
