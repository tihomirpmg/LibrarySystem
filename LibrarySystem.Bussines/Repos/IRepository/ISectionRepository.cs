using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    /// <summary>
    /// Interface SectionRepository class
    /// </summary>
    public interface ISectionRepository
    {
        /// <summary>
        /// CreateSectionAsync method
        /// </summary>
        /// <param name="sectionDto">SectionDto parameter</param>
        /// <returns></returns>
        public Task<SectionDto> CreateSectionAsync(SectionDto sectionDto);
        /// <summary>
        /// GetSectionAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public Task<SectionDto> GetSectionAsync(int bookId);
        /// <summary>
        /// UpdateSectionAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <param name="sectionDto">SectionDto parameter</param>
        /// <returns></returns>
        public Task<SectionDto> UpdateSectionAsync(int bookId, SectionDto sectionDto);
        /// <summary>
        /// GetAllSectionsAsync method
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<SectionDto>> GetAllSectionsAsync();
    }
}
