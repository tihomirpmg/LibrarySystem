using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    /// <summary>
    /// Interface ImagesRepository class
    /// </summary>
    public interface IImagesRepository
    {
        /// <summary>
        /// CreateNewImageAsync method
        /// </summary>
        /// <param name="imageDto">ImageDto parameter</param>
        /// <returns></returns>
        public int CreateNewImage(ImageDto imageDto);
        /// <summary>
        /// DeleteImageByImageIdAsync method
        /// </summary>
        /// <param name="imageId">Int parameter</param>
        /// <returns></returns>
        public int DeleteImageByImageId(int imageId);
        /// <summary>
        /// DeleteImageByBookIdAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public int DeleteImageByBookId(int bookId);
        /// <summary>
        /// DeleteImageByImageUrlAsync method
        /// </summary>
        /// <param name="imageUrl">String imageUrl parameter</param>
        /// <returns></returns>
        public int DeleteImageByImageUrl(string imageUrl);
        /// <summary>
        /// GetImagesAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public IEnumerable<ImageDto> GetImages(int bookId);
    }
}
