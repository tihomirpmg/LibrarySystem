using AutoMapper;
using DataAcess.Data.Models;
using LibrarySystem.Bussines.Repos.IRepository;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
{
    public class SectionRepository : ISectionRepository
    {
        private readonly LibrarySystemDbContext _db;
        private readonly IMapper _mapper;
        public SectionRepository(LibrarySystemDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<SectionDto> CreateSection(SectionDto sectionDto)
        {
            Section section = _mapper.Map<SectionDto, Section>(sectionDto);
            var addedSection = _db.Section.Add(section);
            await _db.SaveChangesAsync();
            return _mapper.Map<Section, SectionDto>(addedSection.Entity);
        }

        public async Task<IEnumerable<SectionDto>> GetAllSections()
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

        public async Task<SectionDto> GetSection(int bookId)
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

        public async Task<SectionDto> UpdateSection(int bookId, SectionDto sectionDto)
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
