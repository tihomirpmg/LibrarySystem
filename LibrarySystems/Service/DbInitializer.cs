﻿using LibrarySystem.Common;
using LibrarySystem.Data.Data;
using LibrarySystems.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystems.Service
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
            catch(Exception)
            {

            }
            if (_db.Roles.Any(x => x.Name == Details.Role_Admin)) return;

            _roleManager.CreateAsync(new IdentityRole(Details.Role_Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Details.Role_Librarian)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Details.Role_Reader)).GetAwaiter().GetResult(); 

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            },"Admin123*").GetAwaiter().GetResult();

            IdentityUser user = _db.Users.FirstOrDefault(u => u.Email == "admin@gmail.com");
            _userManager.AddToRoleAsync(user, Details.Role_Admin).GetAwaiter().GetResult();
        }
    }
}
