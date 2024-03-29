﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAcess.Data.Models;
using LibrarySystem.Data.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Business.Repos;

/// <summary>
/// Title repository class
/// </summary>
public class TitleRepository : ITitleRepository
{
    private readonly LibrarySystemDbContext _db;

    public TitleRepository(LibrarySystemDbContext db)
    {
        _db = db;
    }

    ///<inheritdoc/>
    public async Task<TitleDto> CreateAsync(TitleDto titleDto, CancellationToken cancelletaionToken = default)
    {
        Title title = Conversion.ConvertTitle(titleDto);
        var addedTitle = _db.Title.Add(title);
        await _db.SaveChangesAsync(cancelletaionToken);
        var result = Conversion.ConvertTitle(addedTitle.Entity);

        return result;
    }

    ///<inheritdoc/>
    public async Task<IEnumerable<TitleDto>> GetAllAsync(CancellationToken cancelletaionToken = default)
    {
        try
        {
            IEnumerable<Title> titles = _db.Title.Include(x => x.TitleImages);
            IEnumerable<TitleDto> result = titles.Select(Conversion.ConvertTitle);

            await _db.SaveChangesAsync(cancelletaionToken);
            return result;
        }
        catch (Exception ex)
        {
            throw new RepositoryException("Can not get all books.", ex);
        }
    }

    ///<inheritdoc/>
    public async Task<TitleDto> GetAsync(int bookId, CancellationToken cancelletaionToken = default)
    {
        try
        {
            Title title = await _db.Title.Include(x => x.TitleImages).FirstOrDefaultAsync(x => x.Id == bookId, cancelletaionToken);
            TitleDto result = Conversion.ConvertTitle(title);

            return result;
        }
        catch (Exception ex)
        {
            throw new RepositoryException("Can not get this book", ex);
        }
    }

    ///<inheritdoc/>
    public async Task DeleteAsync(int bookId, CancellationToken cancelletaionToken = default)
    {
        var book = await _db.Title.FindAsync(bookId);

        if (book is null)
        {
            throw new RepositoryException("Error.");
        }

        _db.Title.Remove(book);
        await _db.SaveChangesAsync(cancelletaionToken);
    }

    ///<inheritdoc/>
    public async Task<TitleDto> GetUniqueAsync(string name, int bookId = 0, CancellationToken cancelletaionToken = default)
    {
        try
        {
            if (bookId == 0)
            {
                Title title = await _db.Title.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower(), cancelletaionToken);
                TitleDto result = Conversion.ConvertTitle(title);

                return result;
            }
            else
            {
                Title title = await _db.Title.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.Id == bookId, cancelletaionToken);
                TitleDto result = Conversion.ConvertTitle(title);

                return result;
            }
        }
        catch (Exception ex)
        {
            throw new RepositoryException("Book is not unique.", ex);
        }
    }

    ///<inheritdoc/>
    public async Task<TitleDto> UpdateAsync(int bookId, TitleDto titleDto, CancellationToken cancelletaionToken = default)
    {
        try
        {
            if (bookId == titleDto.Id)
            {
                Title title = await _db.Title.FindAsync(bookId);
                Title convertedTitle = Conversion.ConvertUpdate(title, titleDto);
                var updatedTitle = _db.Title.Update(convertedTitle);
                await _db.SaveChangesAsync(cancelletaionToken);
                var result = Conversion.ConvertTitle(updatedTitle.Entity);
                return result;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            throw new RepositoryException("Book cannot be updated.", ex);
        }
    }
}
