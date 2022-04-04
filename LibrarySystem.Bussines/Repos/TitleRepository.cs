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

        public async Task<TitleDTO> CreateBook(TitleDTO titleDTO)
        {
            Title title = _mapper.Map<TitleDTO, Title>(titleDTO);
            var addedTitle = _db.Title.Add(title);
            await _db.SaveChangesAsync();
            return _mapper.Map<Title, TitleDTO>(addedTitle.Entity);
        }

        public async Task<IEnumerable<TitleDTO>> GetAllBooks()
        {
            try
            {
                IEnumerable<TitleDTO> titleDTOs = _mapper.Map<IEnumerable<Title>, IEnumerable<TitleDTO>>(_db.Title.Include(x => x.TitleImages));
                return titleDTOs;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get all books.");
            }
        }

        public async Task<TitleDTO> GetBook(int bookId)
        {
            try
            {
                TitleDTO title = _mapper.Map<Title, TitleDTO>(
                    await _db.Title.Include(x=>x.TitleImages).FirstOrDefaultAsync(x => x.Id == bookId));
                return title;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get this book");
            }
        }
        public async Task<int> DeleteBook(int bookId)
        {
            var bookDetails = await _db.Title.FindAsync(bookId);
            if (bookDetails != null)
            {
                _db.Title.Remove(bookDetails);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<TitleDTO> IsBookUnique(string name, int bookId = 0)
        {
            try
            {
                if (bookId == 0)
                {
                    TitleDTO title = _mapper.Map<Title, TitleDTO>(
                                        await _db.Title.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
                    return title;
                }
                else
                {
                    TitleDTO title = _mapper.Map<Title, TitleDTO>(
                                        await _db.Title.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()
                                        && x.Id != bookId));
                    return title;
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Book is not unique.");
            }
        }

        public async Task<TitleDTO> UpdateBook(int bookId, TitleDTO titleDTO)
        {
            try
            {
                if (bookId == titleDTO.Id)
                {
                    //valid
                    Title bookDetails = await _db.Title.FindAsync(bookId);
                    Title book = _mapper.Map<TitleDTO, Title>(titleDTO, bookDetails);
                    var updatedBook = _db.Title.Update(book);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Title, TitleDTO>(updatedBook.Entity);
                }
                else
                {
                    //invalid
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Book cannot be updated.");
            }
        }
    }
}
