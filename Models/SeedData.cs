using LoginAndCRUDCoreProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace LoginAndCRUDCoreProject.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Roles.Any())
                {
                    return;   // DB has been seeded
                }
                context.Roles.AddRange(
                    new IdentityRole
                    {
                        Name = "Admin"
                    },
                    new IdentityRole
                    {
                        Name = "User"
                    }
               );
                context.SaveChanges();
            }
            //var _context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            //_context.Database.EnsureCreated();
            //var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //var roleName = "Admin";
            //IdentityResult result;
            //var roleExist = await roleManager.RoleExistsAsync(roleName);
            //if (!roleExist)
            //{
            //    result = await roleManager.CreateAsync(new IdentityRole(roleName));
            //    if (result.Succeeded)
            //    {
            //        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            //        var config = serviceProvider.GetRequiredService<IConfiguration>();
            //        var admin = await userManager.FindByEmailAsync(config["AdminCredentials:Email"]);

            //        if (admin == null)
            //        {
            //            admin = new IdentityUser()
            //            {
            //                UserName = config["AdminCredentials:Email"],
            //                Email = config["AdminCredentials:Email"],
            //                EmailConfirmed = true
            //            };
            //            result = await userManager.CreateAsync(admin, config["AdminCredentials:Password"]);
            //            if (result.Succeeded)
            //            {
            //                result = await userManager
            //                    .AddToRoleAsync(admin, roleName);
            //                if (!result.Succeeded)
            //                {
            //                    // todo: process errors
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }
}
