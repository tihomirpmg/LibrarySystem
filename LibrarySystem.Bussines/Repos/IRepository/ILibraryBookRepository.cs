﻿using LibrarySystem.Bussines.Repos.IRepository;
using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Repos
{
    /// <summary>
    /// Interface LibraryBookRepository class
    /// </summary>
    public interface ILibraryBookRepository : IBaseRepository<LibraryBookDTo>
    {
        /// <summary>
        /// Deletes book.
        /// </summary>
        /// <param name="bookId">the book ID</param>
        /// <returns>an empty result</returns>
        public Task DeleteAsync(int bookId, CancellationToken cancelletaionToken = default);

        /// <summary>
        /// Check if the book is unique. 
        /// </summary>
        /// <param name="name">the book name</param>
        /// <param name="bookId">the book ID</param>
        /// <returns>the result</returns>
        public Task<LibraryBookDTo> GetUniqueAsync(string name, int bookId = 0, CancellationToken cancelletaionToken = default);
    }
}
