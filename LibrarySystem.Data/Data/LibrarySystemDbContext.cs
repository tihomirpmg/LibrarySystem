using DataAcess.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data.Data;

/// <summary>
/// LibrarySystemDbContext class
/// </summary>
public class LibrarySystemDbContext : IdentityDbContext<IdentityUser>
{
    public LibrarySystemDbContext()
    {
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="options">Options parameter</param>
    public LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options)
        : base(options)
    {
    }
    /// <summary>
    /// LibraryBook property
    /// </summary>
    public DbSet<LibraryBook> LibraryBook { get; set; }

    /// <summary>
    /// User property
    /// </summary>
    public DbSet<User> User { get; set; }

    /// <summary>
    /// Section property
    /// </summary>
    public DbSet<Section> Section { get; set; }

    /// <summary>
    /// Moving property
    /// </summary>
    public DbSet<Moving> Moving { get; set; }

    /// <summary>
    /// Title property
    /// </summary>
    public DbSet<Title> Title { get; set; }

    /// <summary>
    /// Images property
    /// </summary>
    public DbSet<Image> Image { get; set; }
}
