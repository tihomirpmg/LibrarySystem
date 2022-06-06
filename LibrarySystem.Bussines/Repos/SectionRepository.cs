using AutoMapper;
using DataAcess.Data.Models;
using LibrarySystem.Bussines.Repos;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    /// <summary>
    /// SectionRepository class
    /// </summary>
    public class SectionRepository : ISectionRepository
    {
        private readonly LibrarySystemDbContext _db;
        private readonly IMapper _mapper;
        public SectionRepository(LibrarySystemDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        /// <summary>
        /// This method create section
        /// </summary>
        /// <param name="sectionDto">Parameter</param>
        /// <returns></returns>
        public async Task<SectionDto> CreateSectionAsync(SectionDto sectionDto)
        {
            Section section = _mapper.Map<SectionDto, Section>(sectionDto);
            var addedSection = _db.Section.Add(section);
            await _db.SaveChangesAsync();
            return _mapper.Map<Section, SectionDto>(addedSection.Entity);
        }
        /// <summary>
        /// Get all sections
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SectionDto>> GetAllSectionsAsync()
        {
            try
            {
                IEnumerable<SectionDto> sectionDtos = _mapper.Map<IEnumerable<Section>, IEnumerable<SectionDto>>(_db.Section);
                return sectionDtos;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get the sections", ex);
            }
        }
        /// <summary>
        /// This method check if the section exist to use it
        /// </summary>
        /// <param name="bookId">Parameter</param>
        /// <returns></returns>
        public async Task<SectionDto> GetSectionAsync(int bookId)
        {
            try
            {
                SectionDto section = _mapper.Map<Section, SectionDto>(
                await _db.Section.FirstOrDefaultAsync(x => x.Id == bookId));
                return section;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Section does not exist.", ex);
            }
        }
        /// <summary>
        /// This method is for the update button in sections
        /// </summary>
        /// <param name="bookId">Parameter</param>
        /// <param name="sectionDto">Parameter</param>
        /// <returns></returns>
        public async Task<SectionDto> UpdateSectionAsync(int bookId, SectionDto sectionDto)
        {
            try
            {
                if (bookId == sectionDto.Id)
                {
                    Section bookDetails = await _db.Section.FindAsync(bookId);
                    Section book = _mapper.Map<SectionDto, Section>(sectionDto, bookDetails);
                    var updatedBook = _db.Section.Update(book);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Section, SectionDto>(updatedBook.Entity);
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
