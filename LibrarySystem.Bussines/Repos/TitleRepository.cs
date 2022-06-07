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
    /// Title repository class
    /// </summary>
    public class TitleRepository : ITitleRepository
    {
        private readonly LibrarySystemDbContext _db;
        public TitleRepository(LibrarySystemDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Create book in the Title database
        /// </summary>
        /// <param name="titleDto">Parameter</param>
        /// <returns></returns>
        public TitleDto CreateBook(TitleDto titleDto)
        {
            Title title = new Title(titleDto);
            var addedTitle = _db.Title.Add(title);
            _db.SaveChanges();
            return new TitleDto(addedTitle.Entity.Id, 
                addedTitle.Entity.Name, 
                addedTitle.Entity.Description, 
                addedTitle.Entity.Writer, 
                addedTitle.Entity.ReleaseYear,
                addedTitle.Entity.Isbn, 
                addedTitle.Entity.Type, 
                addedTitle.Entity.ImageContent, 
                addedTitle.Entity.ImageName,
                addedTitle.Entity.Publisher, 
                addedTitle.Entity.Section);
        }
        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TitleDto> GetAllBooks()
        {
            try
            {
                var titleDtos = (from s in this._db.Title
                                   select new TitleDto
                                   {
                                       Id = s.Id,
                                       Name = s.Name,
                                       Description = s.Description,
                                       Writer = s.Writer,
                                       ReleaseYear = s.ReleaseYear,
                                       Isbn = s.Isbn,
                                       Type = s.Type,
                                       ImageContent = s.ImageContent,
                                       ImageName = s.ImageName,
                                       Publisher = s.Publisher,
                                       Section = s.Section,
                                   }).ToList();
                                       
                return titleDtos;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get all books.", ex);
            }
        }
        /// <summary>
        /// Get book
        /// </summary>
        /// <param name="bookId">Parameter</param>
        /// <returns></returns>
        public TitleDto GetBook(int bookId)
        {
            try
            {
                var titles = this._db.Title.Include(x => x.TitleImages);
                var title = titles.Where(x =>x.Id == bookId).FirstOrDefault();
                return new TitleDto(
                    title.Id,
                    title.Name,
                    title.Description,
                    title.Writer,
                    title.ReleaseYear,
                    title.Isbn,
                    title.Type,
                    title.ImageContent,
                    title.ImageName,
                    title.Publisher,
                    title.Section);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get this book", ex);
            }
        }
        /// <summary>
        /// Delete book from database
        /// </summary>
        /// <param name="bookId">Parameter</param>
        /// <returns></returns>
        public int DeleteBook(int bookId)
        {
            var bookDetails = _db.Title.Find(bookId);
            if (bookDetails != null)
            {
                _db.Title.Remove(bookDetails);
                return _db.SaveChanges();
            }
            return 0;
        }
        /// <summary>
        /// Check if the book exist
        /// </summary>
        /// <param name="name">Parameter</param>
        /// <param name="bookId">Parameter</param>
        /// <returns></returns>
        public TitleDto GetUniqueBook(string name, int bookId = 0)
        {
            try
            {
                if (bookId == 0)
                {
                    var title = this._db.Title.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
                    return new TitleDto();
                }
                else
                {
                    var title = this._db.Title.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()&& x.Id != bookId);
                    return new TitleDto();
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Book is not unique.", ex);
            }
        }
        /// <summary>
        /// Update book in the database
        /// </summary>
        /// <param name="bookId">Parameter</param>
        /// <param name="titleDto">Parameter</param>
        /// <returns></returns>
        public TitleDto UpdateBook(int bookId, TitleDto titleDto)
        {
            try
            {
                if (bookId == titleDto.Id)
                {
                    //valid
                    Title bookDetails = this._db.Title.Find(bookId);
                    Title book = new Title(titleDto);
                    var updatedBook = _db.Title.Update(book);
                    _db.SaveChanges();
                    return new TitleDto();
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
