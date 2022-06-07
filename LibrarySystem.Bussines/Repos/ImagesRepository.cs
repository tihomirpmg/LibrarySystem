using LibrarySystem.Bussines.Repos;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    /// <summary>
    /// Images Repository class
    /// </summary>
    public class ImagesRepository:IImagesRepository
    {
        private readonly LibrarySystemDbContext _db;
        public ImagesRepository(LibrarySystemDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Add image in the database
        /// </summary>
        /// <param name="imageDto">Parameter</param>
        /// <returns></returns>
        public int CreateNewImage(ImageDto imageDto)
        {
            var image = new Images(imageDto);
            _db.Images.Add(image);
            return _db.SaveChanges();
        }
        /// <summary>
        /// Delete image by book id
        /// </summary>
        /// <param name="bookId">Parameter</param>
        /// <returns></returns>
        public int DeleteImageByBookId(int bookId)
        {
            var imageList = _db.Images.Where(x=>x.BookId==bookId).ToList();
            _db.Images.RemoveRange(imageList);
            return _db.SaveChanges();
        }
        /// <summary>
        /// Delete image by image id
        /// </summary>
        /// <param name="imageId">Parameter</param>
        /// <returns></returns>
        public int DeleteImageByImageId(int imageId)
        {
            var image = this._db.Images.Find(imageId);
            this._db.Images.Remove(image);
            return _db.SaveChanges();
        }
        /// <summary>
        /// Delete image by image url
        /// </summary>
        /// <param name="imageUrl">Parameter</param>
        /// <returns></returns>
        public int DeleteImageByImageUrl(string imageUrl)
        {
            var allImages = this._db.Images.FirstOrDefault
                             (x => x.BookImageUrl.ToLower() == imageUrl.ToLower());
            _db.Images.Remove(allImages);
            return _db.SaveChanges();
        }
        /// <summary>
        /// Get image by book id
        /// </summary>
        /// <param name="bookId">Parameter</param>
        /// <returns></returns>
        public IEnumerable<ImageDto> GetImages(int bookId)
        {
            var image = _db.Images.Where(x => x.BookId == bookId).ToList();
            return (IEnumerable<ImageDto>)image;
        }
    }
}
