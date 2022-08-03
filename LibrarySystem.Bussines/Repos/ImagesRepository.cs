using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Business.Repos;

/// <summary>
/// Image Repository class
/// </summary>
public class ImageRepository : IImagesRepository
{
    private readonly LibrarySystemDbContext _db;
    public ImageRepository(LibrarySystemDbContext db)
    {
        _db = db;
    }

    ///<inheritdoc/>
    public async Task<int> CreateNewImageAsync(ImageDto imageDto, CancellationToken cancelletaionToken = default)
    {
        Image image = Conversion.ConvertImage(imageDto);
        await _db.Image.AddAsync(image);
        return await _db.SaveChangesAsync(cancelletaionToken);
    }

    ///<inheritdoc/>
    public async Task<int> DeleteImageByBookIdAsync(int bookId, CancellationToken cancelletaionToken = default)
    {
        var imageList = await _db.Image.Where(x => x.BookId == bookId).ToListAsync();
        _db.Image.RemoveRange(imageList);
        return await _db.SaveChangesAsync(cancelletaionToken);
    }

    ///<inheritdoc/>
    public async Task<int> DeleteImageByImageIdAsync(int imageId, CancellationToken cancelletaionToken = default)
    {
        var image = await _db.Image.FindAsync(imageId);
        _db.Image.Remove(image);
        return await _db.SaveChangesAsync(cancelletaionToken);
    }

    ///<inheritdoc/>
    public async Task<int> DeleteImageByImageUrlAsync(string imageUrl, CancellationToken cancelletaionToken = default)
    {
        var allImage = await _db.Image.FirstOrDefaultAsync
                         (x => x.BookImageUrl.ToLower() == imageUrl.ToLower());
        _db.Image.Remove(allImage);
        return await _db.SaveChangesAsync(cancelletaionToken);
    }
}
