namespace LibrarySystem.Models
{
    /// <summary>
    /// ImageDto class
    /// </summary>
    public class ImageDto
    {
        /// <summary>
        /// ImageDto Id property
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ImageDto BookId property
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// ImageDto BookImageUrl property
        /// </summary>
        public string BookImageUrl { get; set; }

        public virtual TitleDto Title { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public ImageDto()
        {
        }
    }
}
