using LibrarySystem.Models;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Repos
{
    /// <summary>
    /// Interface ImagesRepository class
    /// </summary>
    public interface IImagesRepository
    {
        /// <summary>
        /// Creates a image.
        /// </summary>
        /// <param name="imageDto">the image</param>
        /// <returns>the newly created image</returns>
        public Task<int> CreateNewImageAsync(ImageDto imageDto);

        /// <summary>
        /// Deletes image by ID.
        /// </summary>
        /// <param name="imageId">the image ID</param>
        /// <returns></returns>
        public Task<int> DeleteImageByImageIdAsync(int imageId);

        /// <summary>
        /// Deletes image by book ID.
        /// </summary>
        /// <param name="bookId">the book ID</param>
        /// <returns></returns>
        public Task<int> DeleteImageByBookIdAsync(int bookId);

        /// <summary>
        /// Deletes image by image url.
        /// </summary>
        /// <param name="imageUrl">the image url</param>
        /// <returns></returns>
        public Task<int> DeleteImageByImageUrlAsync(string imageUrl);
    }
}
