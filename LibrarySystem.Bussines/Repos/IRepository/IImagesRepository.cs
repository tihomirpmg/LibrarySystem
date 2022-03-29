using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos.IRepository
{
    public interface IImagesRepository
    {
        public Task<int> CreateNewImage(ImagesDTO imageDTO);

        public Task<int> DeleteImageByImageId(int imageId);

        public Task<int> DeleteImageByBookId(int bookId);

        public Task<int> DeleteImageByImageUrl(string imageUrl);

        public Task<IEnumerable<ImagesDTO>> GetImages(int bookId);
    }
}
