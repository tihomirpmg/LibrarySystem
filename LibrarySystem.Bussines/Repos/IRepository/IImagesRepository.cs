using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    public interface IImagesRepository
    {
        public Task<int> CreateNewImage(ImageDto imageDto);

        public Task<int> DeleteImageByImageId(int imageId);

        public Task<int> DeleteImageByBookId(int bookId);

        public Task<int> DeleteImageByImageUrl(string imageUrl);

        public Task<IEnumerable<ImageDto>> GetImages(int bookId);
    }
}
