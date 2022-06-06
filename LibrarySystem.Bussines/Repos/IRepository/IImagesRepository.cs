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
        public Task<int> CreateNewImageAsync(ImageDto imageDto);
        /// <summary>
        /// DeleteImageByImageIdAsync method
        /// </summary>
        /// <param name="imageId">Int parameter</param>
        /// <returns></returns>
        public Task<int> DeleteImageByImageIdAsync(int imageId);
        /// <summary>
        /// DeleteImageByBookIdAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public Task<int> DeleteImageByBookIdAsync(int bookId);
        /// <summary>
        /// DeleteImageByImageUrlAsync method
        /// </summary>
        /// <param name="imageUrl">String imageUrl parameter</param>
        /// <returns></returns>
        public Task<int> DeleteImageByImageUrlAsync(string imageUrl);
        /// <summary>
        /// GetImagesAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public Task<IEnumerable<ImageDto>> GetImagesAsync(int bookId);
    }
}
