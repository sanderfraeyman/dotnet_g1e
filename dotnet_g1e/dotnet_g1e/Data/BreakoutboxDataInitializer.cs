using dotnet_g1e.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_g1e.Data
{
    public class BreakoutboxDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public BreakoutboxDataInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        private async Task InitializeUsers()
        {
            string email = "admin@breakoutbox.com";
            ApplicationUser user = new ApplicationUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, "P@sswo0rd");
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                await InitializeUsers();

                //initialize other data
            }
        }
    }
}
