using DataAcess.Data.Models;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Business.Repos
{
    /// <summary>
    /// SectionRepository class
    /// </summary>
    public class SectionRepository : ISectionRepository
    {
        private readonly LibrarySystemDbContext _db;
        public SectionRepository(LibrarySystemDbContext db)
        {
            _db = db;
        }

        ///<inheritdoc/>
        public async Task<SectionDto> CreateSectionAsync(SectionDto sectionDto)
        {
            Section section = Conversion.ConvertSection(sectionDto);
            var addedSection = _db.Section.Add(section);
            await _db.SaveChangesAsync();
            var result = Conversion.ConvertSection(addedSection.Entity);
            return result;
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<SectionDto>> GetAllSectionsAsync()
        {
            try
            {
                IEnumerable<Section> sections = _db.Section;
                IEnumerable<SectionDto> result = sections.Select(Conversion.ConvertSection);

                return result;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get the sections", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<SectionDto> GetSectionAsync(int bookId)
        {
            try
            {
                Section section = await _db.Section.FirstOrDefaultAsync(x => x.Id == bookId);
                SectionDto result = Conversion.ConvertSection(section);

                return result;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Section does not exist.", ex);
            }
        }

        ///<inheritdoc/>
        public async Task<SectionDto> UpdateSectionAsync(int bookId, SectionDto sectionDto)
        {
            try
            {
                if (bookId == sectionDto.Id)
                {
                    Section details = await _db.Section.FindAsync(bookId);
                    SectionDto book = Conversion.ConvertSection(details);
                    var updatedBook = _db.Section.Update(details);
                    await _db.SaveChangesAsync();
                    var result = Conversion.ConvertSection(updatedBook.Entity);
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Section cannot be updated.", ex);
            }
        }
    }
}
