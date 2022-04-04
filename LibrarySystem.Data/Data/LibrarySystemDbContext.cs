using DataAcess.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data.Data
{
    public class LibrarySystemDbContext : IdentityDbContext
    {
        public  LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options) : base(options)
        {

        }
        public DbSet<LibraryBook> LibraryBook { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Section> Section { get; set; }

        public DbSet<Moving> Moving { get; set; }

        public DbSet<Title> Title { get; set; }

        public DbSet<Images> Images { get; set; }
    }
}
