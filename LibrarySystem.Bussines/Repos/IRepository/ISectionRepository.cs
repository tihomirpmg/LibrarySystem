using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    public interface ISectionRepository
    {
        public Task<SectionDto> CreateSectionAsync(SectionDto sectionDto);
        public Task<SectionDto> GetSectionAsync(int bookId);
        public Task<SectionDto> UpdateSectionAsync(int bookId, SectionDto sectionDto);
        public Task<IEnumerable<SectionDto>> GetAllSectionsAsync();
    }
}
