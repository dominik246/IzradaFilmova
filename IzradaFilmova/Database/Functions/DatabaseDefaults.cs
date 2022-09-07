using IzradaFilmova.Database.Context;

using Microsoft.AspNetCore.Identity;

using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace IzradaFilmova.Database.Functions
{
    public static class DatabaseDefaults
    {
        public static async Task SeedDatabaseDefaults([NotNull] this WebApplication app)
        {
            var userManager = app.Services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = app.Services.GetRequiredService<RoleManager<IdentityRole>>();

            var resultArr = new List<IdentityResult?>
            {
                await roleManager.AddRoleIfNotExists("SuperAdmin"),
                await roleManager.AddRoleIfNotExists("Actor"),
                await roleManager.AddRoleIfNotExists("Director"),

                await userManager.AddUserIfNotExists("Admin", "Password123%", "admin@admin.com")
            };

            if (resultArr.Find(p => p is not { Succeeded: true }) is not null)
            {
                throw new InvalidOperationException("Failed to build user and roles");
            }
        }

        private static async Task<IdentityResult?> AddRoleIfNotExists(this RoleManager<IdentityRole> roleManager, string role)
        {
            var superAdminRole = await roleManager.RoleExistsAsync(role);
            if (superAdminRole)
            {
                return IdentityResult.Success;
            }

            return await roleManager.CreateAsync(new IdentityRole
            {
                Name = role,
                NormalizedName = role.ToUpperInvariant()
            });
        }

        private static async Task<IdentityResult?> AddUserIfNotExists(this UserManager<IdentityUser> userManager, string userName, string password, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is not null)
            {
                return IdentityResult.Success;
            }

            return await userManager.CreateAsync(new IdentityUser
            {
                Email = email,
                EmailConfirmed = true,
                UserName = userName,
                NormalizedUserName = userName.ToUpperInvariant(),
                NormalizedEmail = email.ToUpperInvariant()
            }, password);
        }
    }
}
