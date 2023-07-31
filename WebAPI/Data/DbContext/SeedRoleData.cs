using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DbContext
{
    public static class SeedRoleData
    {
        public static void Seed(this ModelBuilder builder)
        {
            var pwdAdmin = "Admin@123";
            var pwdUser = "User@123";
            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Add Roles
            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name.ToUpper();

            var userRole = new IdentityRole("User");
            userRole.NormalizedName = userRole.Name.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>() {
            adminRole,
            userRole
            };

            builder.Entity<IdentityRole>().HasData(roles);


            // Add Users
            var adminUser = new IdentityUser
            {
                UserName = "Admin@gmail.com",
                Email = "Admin@gmail.com",
                EmailConfirmed = true,
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwdAdmin);

            var memberUser = new IdentityUser
            {
                UserName = "User@gmail.com",
                Email = "User@gmail.com",
                EmailConfirmed = true,
            };
            memberUser.NormalizedUserName = memberUser.UserName.ToUpper();
            memberUser.NormalizedEmail = memberUser.Email.ToUpper();
            memberUser.PasswordHash = passwordHasher.HashPassword(memberUser, pwdUser);

            List<IdentityUser> users = new List<IdentityUser>() {
                adminUser,
                memberUser,
            };

            builder.Entity<IdentityUser>().HasData(users);

            // Assign UserRoles

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });   

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "User").Id
            });

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}
