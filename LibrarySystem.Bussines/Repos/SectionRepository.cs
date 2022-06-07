using DataAcess.Data.Models;
using LibrarySystem.Bussines.Repos;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Bussines.Repos
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
        /// <summary>
        /// This method create section
        /// </summary>
        /// <param name="sectionDto">Parameter</param>
        /// <returns></returns>
        public SectionDto CreateSection(SectionDto sectionDto)
        {
            Section section = new Section(sectionDto);
            var addedSection = _db.Section.Add(section);
            _db.SaveChanges();
            return new SectionDto(
                addedSection.Entity.Id,
                addedSection.Entity.Name,
                addedSection.Entity.Book,
                addedSection.Entity.Description);

        }
        /// <summary>
        /// Get all sections
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SectionDto> GetAllSections()
        {
            try
            {
                var sectionDtos = (from s in this._db.Section
                                  select new SectionDto
                                  {
                                      Id = s.Id,
                                      Name = s.Name,
                                      Book = s.Book,
                                      Description = s.Description,
                                  }).ToList();
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
        public SectionDto GetSection(int bookId)
        {
            try
            {
                var section = this._db.Section.Where(x => x.Id == bookId).FirstOrDefault();
                return new SectionDto(
                       section.Id,
                       section.Name,
                       section.Book,
                       section.Description);
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
        public SectionDto UpdateSection(int bookId, SectionDto sectionDto)
        {
            try
            {
                if (bookId == sectionDto.Id)
                {
                    Section bookDetails = this._db.Section.Find(bookId);
                    Section book = new Section(sectionDto);
                    var updatedBook = _db.Section.Update(book);
                    _db.SaveChanges();
                    return new SectionDto(
                               updatedBook.Entity.Id,
                               updatedBook.Entity.Name,
                               updatedBook.Entity.Book,
                               updatedBook.Entity.Description);
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
