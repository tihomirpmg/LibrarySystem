using System;
using System.Linq;
using LibrarySystem.Common;
using LibrarySystem.Data.Data;
using LibrarySystem.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Service
{
    public class DbInitializer : IDbInitializer
    {
        private readonly LibrarySystemDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(LibrarySystemDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

            }
            if (_db.Roles.Any(x => x.Name == RoleNames.Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(RoleNames.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(RoleNames.Librarian)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(RoleNames.Reader)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            }, "Admin123*").GetAwaiter().GetResult();

            IdentityUser user = _db.Users.FirstOrDefault(u => u.Email == "admin@gmail.com");
            _userManager.AddToRoleAsync(user, RoleNames.Admin).GetAwaiter().GetResult();
        }
    }
}
