using LibrarySystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos.IRepository
{
    public interface ISectionRepository
    {
        public Task<SectionDto> CreateSection(SectionDto sectionDto);
        public Task<SectionDto> GetSection(int bookId);
        public Task<SectionDto> UpdateSection(int bookId, SectionDto sectionDto);
        public Task<IEnumerable<SectionDto>> GetAllSections();
    }
}
