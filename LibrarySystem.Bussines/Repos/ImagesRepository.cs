using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Repos
{
    /// <summary>
    /// Images Repository class
    /// </summary>
    public class ImagesRepository : IImagesRepository
    {
        private readonly LibrarySystemDbContext _db;
        public ImagesRepository(LibrarySystemDbContext db)
        {
            _db = db;
        }

        ///<inheritdoc/>
        public async Task<int> CreateNewImageAsync(ImageDto imageDto, CancellationToken cancelletaionToken = default)
        {
            Image image = Conversion.ConvertImage(imageDto);
            await _db.Images.AddAsync(image);
            return await _db.SaveChangesAsync(cancelletaionToken);
        }

        ///<inheritdoc/>
        public async Task<int> DeleteImageByBookIdAsync(int bookId, CancellationToken cancelletaionToken = default)
        {
            var imageList = await _db.Images.Where(x => x.BookId == bookId).ToListAsync();
            _db.Images.RemoveRange(imageList);
            return await _db.SaveChangesAsync(cancelletaionToken);
        }

        ///<inheritdoc/>
        public async Task<int> DeleteImageByImageIdAsync(int imageId, CancellationToken cancelletaionToken = default)
        {
            var image = await _db.Images.FindAsync(imageId);
            _db.Images.Remove(image);
            return await _db.SaveChangesAsync(cancelletaionToken);
        }

        ///<inheritdoc/>
        public async Task<int> DeleteImageByImageUrlAsync(string imageUrl, CancellationToken cancelletaionToken = default)
        {
            var allImages = await _db.Images.FirstOrDefaultAsync
                             (x => x.BookImageUrl.ToLower() == imageUrl.ToLower());
            _db.Images.Remove(allImages);
            return await _db.SaveChangesAsync(cancelletaionToken);
        }
    }
}
