using IdentityServices.Models;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace IdentityServices.Data
{
    public class ApplicationDbContextSeed
    {
        public async static Task SeedAsync(ApplicationDbContext context, IWebHostEnvironment env, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            try
            {
                //inlezen vanop Setup
                var contentRootPath = env.ContentRootPath;
                var webroot = env.WebRootPath;

                await SeedRoles(roleManager);
                await context.SaveChangesAsync();

                await SeedAdmins(userManager, roleManager);
                await context.SaveChangesAsync();

                await SeedUsers(userManager, roleManager);
                ////TODO: await SeedUsersFromFile();
                //await SeedUsersFromFile(contentRootPath, userManager, roleManager, context);

                await context.SaveChangesAsync();



            }
            catch
            {



            }

        }

        private async static Task SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (userManager.FindByNameAsync("Customer@1").Result == null)
            {
                User customer1 = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "customer1@howest.be",
                    Email = "customer1@howest.be",
                    CardNumber = "3333 3333 3333 3333"
                };
                var userResult = await userManager.CreateAsync(customer1, "Customer@1");
                await userManager.AddToRoleAsync(customer1, "Customer");

                if (!userResult.Succeeded)
                {
                    throw new Exception($"{customer1.Email} not logged in");
                }
            }
        }


        private async static Task SeedAdmins(UserManager<User> userManager, RoleManager<Role> roleManager)
        {

            if (userManager.FindByNameAsync("docent@howest.be").Result == null)
            {
                User admin = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "docent@howest.be",
                    Email = "docent@howest.be",
                    CardNumber = "1111 1111 1111 1111"
                };


                var userResult = await userManager.CreateAsync(admin, "Docent@1");
                var role = roleManager.Roles.Where(r => r.Name.StartsWith("Admin")).FirstAsync().Result;
                await userManager.AddToRoleAsync(admin, role.Name);
                if (!userResult.Succeeded)
                {
                    throw new Exception($"{admin.Email} not logged in");
                }
            }
            if (userManager.FindByNameAsync("Jonas").Result == null)
            {
                User admin = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "Jonas",
                    Email = "jonasanne@outlook.com",
                    CardNumber = "1111 1111 1111 1111"
                };

                var userResult = await userManager.CreateAsync(admin, "Student@1");
                var role = roleManager.Roles.Where(r => r.Name.StartsWith("Admin")).FirstAsync().Result;
                await userManager.AddToRoleAsync(admin, role.Name);

                if (!userResult.Succeeded)
                {
                    throw new Exception($"{admin.Email} not logged in");
                }
            }

        }

        private static async Task SeedRoles(RoleManager<Role> roleManager)
        {
            string[] roleNames = { "Admin", "Customer", "Visitor" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var result = await roleManager.CreateAsync(new Role(roleName));
                }
            }

        }


        //private async static Task SeedUsersFromFile(string contentRootPath, UserManager<User> userManager, RoleManager<Role> roleManager, ApplicationDbContext context)
        //{
        //    return ; //not implemented yet
        //}
    }
}