using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogProjectMVC.Data;
using TheBlogProjectMVC.Enums;
using TheBlogProjectMVC.Models;

namespace TheBlogProjectMVC.Services
{
    public class DataService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;
        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {

            //Create the DB from the Migrations
           await _dbContext.Database.MigrateAsync();
            //1: Seeding a Few Roles into the Sytem.
           await SeedRolesAsync();

            //2: Seed a User into the System
            await SeedUsersAsync();
        }


        private async Task SeedRolesAsync()
        {
            //If there are roles in the system do nothing.
            if (_dbContext.Roles.Any())
            {
                return;
            }
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use role manager to create roles
               await _roleManager.CreateAsync(new IdentityRole(role));
            }

        }

        private async Task SeedUsersAsync()
        {
            if (_dbContext.Users.Any())
            {
                return;
            }

            // Step 1 Create a new instance of BolgUser
            var adminUser = new BlogUser()
            {
                Email = "charlesramcharan@yahoo.com",
                UserName = "charlesramcharan@yahoo.com",
                FirstName = "Charles",
                LastName = "Ramcharan",
                PhoneNumber = "(800) 723-3689",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined  by adminUser
          await _userManager.CreateAsync(adminUser, "Quality@1234");

            //Step 3: Add this new use to eh Administrator role
          await  _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            // Step 1 Create a new instance of Moderator User
            var modUser = new BlogUser()
            {
                Email = "charlesramcharan@gmail.com",
                UserName = "charlesramcharan@gmail.com",
                FirstName = "Junior",
                LastName = "Ramcharan",
                PhoneNumber = "(800) 723-3689",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined  by adminUser
            await _userManager.CreateAsync(modUser, "Quality@1234");

            //Step 3: Add this new use to eh Administrator role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }

    }
}
