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
    /// Title repository class
    /// </summary>
    public class TitleRepository : ITitleRepository
    {
        private readonly LibrarySystemDbContext _db;

        public TitleRepository(LibrarySystemDbContext db)
        {
            _db = db;
        }

        ///<inheritdoc/>
        public async Task<TitleDto> CreateBookAsync(TitleDto titleDto)
        {
            Title title = Conversion.ConvertTitle(titleDto);
            var addedTitle = _db.Title.Add(title);
            await _db.SaveChangesAsync();
            var result = Conversion.ConvertTitle(addedTitle.Entity);

            return result;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<TitleDto>> GetAllBooksAsync()
        {
            try
            {
                IEnumerable<Title> titles = _db.Title.Include(x => x.TitleImages);
                IEnumerable<TitleDto> result = titles.Select(Conversion.ConvertTitle);

                return result;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get all books.", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<TitleDto> GetBookAsync(int bookId)
        {
            try
            {
                Title title = await _db.Title.Include(x => x.TitleImages).FirstOrDefaultAsync(x => x.Id == bookId);
                TitleDto result = Conversion.ConvertTitle(title);

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
            var book = await _db.Title.FindAsync(bookId);

            if (book is null)
            {
                //throw error
            }

            _db.Title.Remove(book);
            await _db.SaveChangesAsync();
        }

        ///<inheritdoc/>
        public async Task<TitleDto> GetUniqueBookAsync(string name, int bookId = 0)
        {
            try
            {
                if (bookId == 0)
                {
                    Title title = await _db.Title.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
                    TitleDto result = Conversion.ConvertTitle(title);

                    return result;
                }
                else
                {
                    Title title = await _db.Title.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.Id == bookId);
                    TitleDto result = Conversion.ConvertTitle(title);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Book is not unique.", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<TitleDto> UpdateBookAsync(int bookId, TitleDto titleDto)
        {
            try
            {
                if (bookId == titleDto.Id)
                {
                    Title title = await _db.Title.FindAsync(bookId);
                    Title convertedTitle = Conversion.ConvertUpdate(title, titleDto);
                    var updatedTitle = _db.Title.Update(convertedTitle);
                    await _db.SaveChangesAsync();
                    var result = Conversion.ConvertTitle(updatedTitle.Entity);
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
