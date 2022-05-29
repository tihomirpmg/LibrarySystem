using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    public interface IImagesRepository
    {
        public Task<int> CreateNewImageAsync(ImageDto imageDto);

        public Task<int> DeleteImageByImageIdAsync(int imageId);

        public Task<int> DeleteImageByBookIdAsync(int bookId);

        public Task<int> DeleteImageByImageUrlAsync(string imageUrl);

        public Task<IEnumerable<ImageDto>> GetImagesAsync(int bookId);
    }
}
