using DataAcess.Data.Models;
using LibrarySystem.Bussines.Repos;
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
        /// <summary>
        /// This method create book in database
        /// </summary>
        /// <param name="libraryBookDto">Parameter</param>
        /// <returns></returns>
        public LibraryBookDto CreateBook(LibraryBookDto libraryBookDto)
        {
            LibraryBook libraryBook = new LibraryBook(libraryBookDto);
            var addedLibraryBook = _db.LibraryBook.Add(libraryBook);
            _db.SaveChanges();
            return new LibraryBookDto(
                addedLibraryBook.Entity.Id,
                addedLibraryBook.Entity.Name,
                addedLibraryBook.Entity.Condition,
                addedLibraryBook.Entity.Bearer,
                addedLibraryBook.Entity.Stock);
        }
        /// <summary>
        /// This method show all books
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LibraryBookDto> GetAllBooks()
        {
            try
            {
                var libraryBookDtos = (from s in this._db.LibraryBook
                                       select new LibraryBookDto
                                       {
                                           Id = s.Id,
                                           Name = s.Name,
                                           Condition = s.Condition,
                                           Bearer = s.Bearer,
                                           Stock = s.Stock,
                                       }).ToList();

                return libraryBookDtos;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get all books.", ex);
            }
        }
        /// <summary>
        /// This method get book
        /// </summary>
        /// <param name="bookId">Parameter</param>
        /// <returns></returns>
        public LibraryBookDto GetBook(int bookId)
        {
            try
            {
                var libraryBook = this._db.LibraryBook.Where(x => x.Id == bookId).FirstOrDefault();
                return new LibraryBookDto(
                    libraryBook.Id,
                    libraryBook.Name,
                    libraryBook.Condition,
                    libraryBook.Bearer,
                    libraryBook.Stock);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get this book", ex);
            }
        }
        /// <summary>
        /// This method delete book from database
        /// </summary>
        /// <param name="bookId">Parameter</param>
        /// <returns></returns>
        public int DeleteBook(int bookId)
        {
            var bookDetails = _db.LibraryBook.Find(bookId);
            if(bookDetails != null)
            {
                _db.LibraryBook.Remove(bookDetails);
                return _db.SaveChanges();
            }
            return 0;
        }
        /// <summary>
        /// This method check if the book exist
        /// </summary>
        /// <param name="name">Parameter</param>
        /// <param name="bookId">Parameter</param>
        /// <returns></returns>
        public LibraryBookDto GetUniqueBook(string name, int bookId=0)
        {
            try
            {
                if (bookId == 0)
                {
                    var libraryBook = this._db.LibraryBook.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
                    return new LibraryBookDto();
                }
                else
                {
                    var libraryBook = this._db.LibraryBook.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()
                                        && x.Id != bookId);
                    return new LibraryBookDto();
                    
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Book is not unique.", ex);
            }
        }
        /// <summary>
        /// This method update book in the database
        /// </summary>
        /// <param name="bookId">Parameter</param>
        /// <param name="libraryBookDto">Parameter</param>
        /// <returns></returns>
        public LibraryBookDto UpdateBook(int bookId, LibraryBookDto libraryBookDto)
        {
            try
            {
                if (bookId == libraryBookDto.Id)
                {
                    //valid
                    LibraryBook bookDetails = this._db.LibraryBook.Find(bookId);
                    LibraryBook book = new LibraryBook(libraryBookDto);
                    var updatedBook = _db.LibraryBook.Update(book);
                    _db.SaveChanges();
                    return new LibraryBookDto(
                        updatedBook.Entity.Id,
                        updatedBook.Entity.Name,
                        updatedBook.Entity.Condition,
                        updatedBook.Entity.Bearer,
                        updatedBook.Entity.Stock
                        );
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
