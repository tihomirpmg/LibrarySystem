using AutoMapper;
using LibrarySystem.Bussines.Repos;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    public class ImagesRepository:IImagesRepository
    {
        private readonly LibrarySystemDbContext _db;
        private readonly IMapper _mapper;
        public ImagesRepository(LibrarySystemDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<int> CreateNewImage(ImageDto imageDto)
        {
            var image = _mapper.Map<ImageDto, Images>(imageDto);
            await _db.Images.AddAsync(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteImageByBookId(int bookId)
        {
            var imageList = await _db.Images.Where(x=>x.BookId==bookId).ToListAsync();
            _db.Images.RemoveRange(imageList);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteImageByImageId(int imageId)
        {
            var image = await _db.Images.FindAsync(imageId);
            _db.Images.Remove(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteImageByImageUrl(string imageUrl)
        {
            var allImages = await _db.Images.FirstOrDefaultAsync
                             (x => x.BookImageUrl.ToLower() == imageUrl.ToLower());
            _db.Images.Remove(allImages);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ImageDto>> GetImages(int bookId)
        {
            return _mapper.Map<IEnumerable<Images>, IEnumerable<ImageDto>>(
            await _db.Images.Where(x => x.BookId == bookId).ToListAsync());
        }
    }
}
