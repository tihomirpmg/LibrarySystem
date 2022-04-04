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

        public async Task<SectionDTO> CreateSection(SectionDTO sectionDTO)
        {
            Section section = _mapper.Map<SectionDTO, Section>(sectionDTO);
            var addedSection = _db.Section.Add(section);
            await _db.SaveChangesAsync();
            return _mapper.Map<Section, SectionDTO>(addedSection.Entity);
        }

        public async Task<IEnumerable<SectionDTO>> GetAllSections()
        {
            try
            {
                IEnumerable<SectionDTO> sectionDTOs = _mapper.Map<IEnumerable<Section>, IEnumerable<SectionDTO>>(_db.Section);
                return sectionDTOs;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Can not get the sections", ex);
            }
        }

        public async Task<SectionDTO> GetSection(int bookId)
        {
            try
            {
                SectionDTO section = _mapper.Map<Section, SectionDTO>(
                await _db.Section.FirstOrDefaultAsync(x => x.Id == bookId));
                return section;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Section does not exist.", ex);
            }
        }

        public async Task<SectionDTO> UpdateSection(int bookId, SectionDTO sectionDTO)
        {
            try
            {
                if (bookId == sectionDTO.Id)
                {
                    Section bookDetails = await _db.Section.FindAsync(bookId);
                    Section book = _mapper.Map<SectionDTO, Section>(sectionDTO, bookDetails);
                    var updatedBook = _db.Section.Update(book);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<Section, SectionDTO>(updatedBook.Entity);
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
