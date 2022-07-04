using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos.IRepository
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Creates a book.
        /// </summary>
        /// <param name="t">the book</param>
        /// <returns>the newly created book</returns>
        public Task<T> CreateAsync(T t, CancellationToken cancelletaionToken = default);

        /// <summary>
        /// Updates book.
        /// </summary>
        /// <param name="bookId">the book ID</param>
        /// <param name="t">the book</param>
        /// <returns>the updated book</returns>
        public Task<T> UpdateAsync(int bookId, T t, CancellationToken cancelletaionToken = default);

        /// <summary>
        /// Retrieves a book with specified ID.
        /// </summary>
        /// <param name="bookId">the book ID</param>
        /// <returns>the book</returns>
        public Task<T> GetAsync(int bookId, CancellationToken cancelletaionToken = default);

        /// <summary>
        /// Retrieves all books.
        /// </summary>
        /// <returns>collection of books</returns>
        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancelletaionToken = default);
    }
}
