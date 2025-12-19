using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Identity
{
    public class AdminInitializer
    {
        public static async Task EnsureAdminAsync(IServiceProvider services, IConfiguration config)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            var email = config["Admin:Email"];
            var password = config["Admin:Password"];

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return;

            const string roleName = "Admin";

            // Ensure role exists
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!roleResult.Succeeded)
                    throw new Exception(string.Join(" | ", roleResult.Errors.Select(e => e.Description)));
            }

            // Find user by email
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = email,          // username = email
                    Email = email,
                    EmailConfirmed = true
                };

                var createResult = await userManager.CreateAsync(user, password);
                if (!createResult.Succeeded)
                    throw new Exception(string.Join(" | ", createResult.Errors.Select(e => e.Description)));
            }
            else
            {
                // Ensure confirmed
                if (!user.EmailConfirmed)
                {
                    user.EmailConfirmed = true;
                    var updateResult = await userManager.UpdateAsync(user);
                    if (!updateResult.Succeeded)
                        throw new Exception(string.Join(" | ", updateResult.Errors.Select(e => e.Description)));
                }
            }

            // Add to role (THIS is what you wanted)
            if (!await userManager.IsInRoleAsync(user, roleName))
            {
                var addRoleResult = await userManager.AddToRoleAsync(user, roleName);
                if (!addRoleResult.Succeeded)
                    throw new Exception(string.Join(" | ", addRoleResult.Errors.Select(e => e.Description)));
            }
        }
    }
}
