using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Repos
{
    /// <summary>
    /// Interface SectionRepository class
    /// </summary>
    public interface ISectionRepository
    {
        /// <summary>
        /// Creates a section.
        /// </summary>
        /// <param name="sectionDto">the section</param>
        /// <returns>the newly created section</returns>
        public Task<SectionDto> CreateSectionAsync(SectionDto sectionDto);

        /// <summary>
        /// Retrieves a section with specified ID.
        /// </summary>
        /// <param name="bookId">the book ID</param>
        /// <returns>the section</returns>
        public Task<SectionDto> GetSectionAsync(int bookId);

        /// <summary>
        /// Updates section.
        /// </summary>
        /// <param name="bookId">the book ID</param>
        /// <param name="sectionDto">>the section</param>
        /// <returns>the updated section</returns>
        public Task<SectionDto> UpdateSectionAsync(int bookId, SectionDto sectionDto);

        /// <summary>
        /// Retrieves all sections.
        /// </summary>
        /// <returns>collection of sections</returns>
        public Task<IEnumerable<SectionDto>> GetAllSectionsAsync();
    }
}
