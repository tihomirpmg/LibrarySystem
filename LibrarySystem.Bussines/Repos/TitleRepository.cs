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
    public class TitleRepository : ITitleRepository
    {
        private readonly LibrarySystemDbContext _db;
        private readonly IMapper _mapper;
        public TitleRepository(LibrarySystemDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<TitleDto> CreateBook(TitleDto titleDto)
        {
            Title title = _mapper.Map<TitleDto, Title>(titleDto);
            var addedTitle = _db.Title.Add(title);
            await _db.SaveChangesAsync();
            return _mapper.Map<Title, TitleDto>(addedTitle.Entity);
        }

        public async Task<IEnumerable<TitleDto>> GetAllBooks()
        {
            try
            {
                IEnumerable<TitleDto> titleDtos = _mapper.Map<IEnumerable<Title>, IEnumerable<TitleDto>>(_db.Title.Include(x => x.TitleImages));
                return titleDtos;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get all books.", ex);
            }
        }

        public async Task<TitleDto> GetBook(int bookId)
        {
            try
            {
                TitleDto title = _mapper.Map<Title, TitleDto>(
                    await _db.Title.Include(x=>x.TitleImages).FirstOrDefaultAsync(x => x.Id == bookId));
                return title;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get this book", ex);
            }
        }

        public async void DeleteBook(int bookId)
        {
            var bookDetails = await _db.Title.FindAsync(bookId);
            if (bookDetails != null)
            {
                _db.Title.Remove(bookDetails);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<TitleDto> UniqueBook(string name, int bookId = 0)
        {
            try
            {
                if (bookId == 0)
                {
                    TitleDto title = _mapper.Map<Title, TitleDto>(
                                        await _db.Title.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
                    return title;
                }
                else
                {
                    TitleDto title = _mapper.Map<Title, TitleDto>(
                                        await _db.Title.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()
                                        && x.Id != bookId));
                    return title;
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Book is not unique.", ex);
            }
        }

        public async Task<TitleDto> UpdateBook(int bookId, TitleDto titleDto)
        {
            try
            {
                if (bookId == titleDto.Id)
                {
                    //valid
                    Title bookDetails = await _db.Title.FindAsync(bookId);
                    Title book = _mapper.Map<TitleDto, Title>(titleDto, bookDetails);
                    var updatedBook = _db.Title.Update(book);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Title, TitleDto>(updatedBook.Entity);
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
