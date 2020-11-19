using System;
using System.Collections.Generic;
using System.Text;
using ePizza_JD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ePizza_JD.WebApp.Data
{
    public partial class RestaurantServicesDbContext : IdentityDbContext
    {
        public RestaurantServicesDbContext()
        {

        }

        public RestaurantServicesDbContext(DbContextOptions<RestaurantServicesDbContext> options)
            : base(options)
        {
        }
        //create tables
        //public virtual DbSet<RestaurantOrder> RestaurantOrders { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }




        //fluent api
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<RestaurantOrder>(e =>
            //{
            //    e.HasKey(e => new { e.OrderId, e.RestaurantId });
            //    e.HasOne(e => e.Restaurant).WithMany(r => r.RestaurantOrder).HasForeignKey(r => r.RestaurantId);
            //    //e.HasOne(e => e.Order).WithMany(r => r.RestaurantOrder).HasForeignKey(r => r.OrderId);
            //});


            builder.Entity<Restaurant>(e =>
            {
                e.HasMany(e => e.Orders).WithOne(e => e.Restaurant);

            });



            OnModelCreatingPartial(builder);
            builder.Seed(); // seeden van testdata
        }

        ////seeden van roles
        //public void SeedRoles(RoleManager<IdentityRole> roleManager)
        //{
        //    //add admin role
        //    if (roleManager.FindByNameAsync("Admin").Result == null)
        //    {
        //        IdentityRole Role = new IdentityRole
        //        {
        //            Name="Admin",
        //            NormalizedName = "admin"
        //        };

        //        IdentityResult result = roleManager.CreateAsync(Role).Result;


        //    }
        //    //add customer role
        //    if (roleManager.FindByNameAsync("Customer").Result == null)
        //    {
        //        IdentityRole Role = new IdentityRole
        //        {
        //            Name = "Customer",
        //            NormalizedName = "customer"
        //        };
        //        IdentityResult result = roleManager.CreateAsync(Role).Result;
        //    }
        //}
        ////seeden van users
        //public void SeedUsers(UserManager<IdentityUser> userManager)
        //{
        //    //add admin "Docent@howest.be"
        //    if (userManager.FindByEmailAsync("docent@howest.com").Result == null)
        //    {
        //        IdentityUser user = new IdentityUser
        //        {
        //            UserName = "docent@howest.com",
        //            Email = "docent@howest.com"
        //        };

        //        IdentityResult result = userManager.CreateAsync(user, "Docent@1").Result;

        //        if (result.Succeeded)
        //        {
        //            userManager.AddToRoleAsync(user, "Admin").Wait();
        //        }
        //    }
        //    //add customer "testuser"
        //    if (userManager.FindByEmailAsync("test@howest.be").Result == null)
        //    {
        //        IdentityUser user = new IdentityUser
        //        {
        //            UserName = "testuser",
        //            Email = "test@howest.be"
        //        };

        //        IdentityResult result = userManager.CreateAsync(user, "Test@1").Result;

        //        if (result.Succeeded)
        //        {
        //            userManager.AddToRoleAsync(user, "Customer").Wait();
        //        }
        //    }
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
