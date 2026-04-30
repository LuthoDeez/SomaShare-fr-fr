using Microsoft.AspNetCore.Identity;
using SomaShare.Models;

namespace SomaShare.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndUsers(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Create roles
            string[] roles = { "Admin", "Seller", "Buyer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Create default Admin
            if (await userManager.FindByEmailAsync("admin@somashare.ac.za") == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin@somashare.ac.za",
                    Email = "admin@somashare.ac.za",
                    FullName = "Admin User",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(admin, "Admin@1234");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
