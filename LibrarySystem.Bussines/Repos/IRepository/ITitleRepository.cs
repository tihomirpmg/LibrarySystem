﻿using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    public interface ITitleRepository
    {
        public Task<TitleDto> CreateBook(TitleDto titleDto);
        public Task<TitleDto> UpdateBook(int bookId, TitleDto titleDto);
        public Task<TitleDto> GetBook(int bookId);
        public void DeleteBook(int bookId);
        public Task<IEnumerable<TitleDto>> GetAllBooks();
        public Task<TitleDto> GetUniqueBook(string name, int bookId = 0);
    }
}
