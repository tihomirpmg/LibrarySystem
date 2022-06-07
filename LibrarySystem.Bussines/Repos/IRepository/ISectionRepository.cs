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
        public SectionDto CreateSection(SectionDto sectionDto);
        /// <summary>
        /// GetSectionAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <returns></returns>
        public SectionDto GetSection(int bookId);
        /// <summary>
        /// UpdateSectionAsync method
        /// </summary>
        /// <param name="bookId">Int parameter</param>
        /// <param name="sectionDto">SectionDto parameter</param>
        /// <returns></returns>
        public SectionDto UpdateSection(int bookId, SectionDto sectionDto);
        /// <summary>
        /// GetAllSectionsAsync method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SectionDto> GetAllSections();
    }
}
