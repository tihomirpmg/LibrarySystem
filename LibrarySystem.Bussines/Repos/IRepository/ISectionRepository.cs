using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos.IRepository
{
    public interface ISectionRepository
    {
        public Task<SectionDTO> CreateSection(SectionDTO sectionDTO);
        public Task<SectionDTO> GetSection(int bookId);
        public Task<SectionDTO> UpdateSection(int bookId, SectionDTO sectionDTO);
        public Task<IEnumerable<SectionDTO>> GetAllSections();
    }
}
