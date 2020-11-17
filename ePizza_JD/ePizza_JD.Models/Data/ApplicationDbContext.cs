using System;
using System.Collections.Generic;
using System.Text;
using ePizza_JD.Models;
using ePizza_JD.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ePizza_JD.WebApp.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //create tables
        public virtual DbSet<Pizza> Pizzas  { get; set; }
        public virtual DbSet<Review> Reviews  { get; set; }
        public virtual DbSet<Topping> Toppings  { get; set; }
        public virtual DbSet<Order> Orders  { get; set; }
        public virtual DbSet<Customer> Customers  { get; set; }
        public virtual DbSet<CustomerOrders> CustomerOrders  { get; set; }
        public virtual DbSet<PizzaToppings> PizzaToppings  { get; set; }
        public virtual DbSet<OrderReviews> OrderReviews  { get; set; }
        public virtual DbSet<RestaurantOrder> RestaurantOrders { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }




        //fluent api
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Pizza>(e =>
            {
                e.Property(e => e.Name).IsRequired();
                e.Property(e => e.Price).IsRequired();
            });
            builder.Entity<CustomerOrders>(e =>
            {
                e.HasKey(e => new { e.CustomerId, e.OrderId });
                e.HasOne(e => e.Customer).WithMany(m => m.CustomerOrders).HasForeignKey(m => m.CustomerId);
                e.HasOne(e => e.Order).WithMany(m => m.CustomerOrders).HasForeignKey(m => m.OrderId);
            });
            builder.Entity<PizzaToppings>(e =>
            {
                e.HasKey(e => new { e.PizzaId, e.ToppingId });
                e.HasOne(e => e.Topping).WithMany(m => m.PizzaToppings).HasForeignKey(m => m.ToppingId);
                e.HasOne(e => e.Pizza).WithMany(m => m.PizzaToppings).HasForeignKey(m => m.PizzaId);
            });

            builder.Entity<OrderReviews>(e =>
            {
                e.HasKey(e => new { e.OrderId, e.ReviewId });
                e.HasOne(e => e.Review).WithMany(r => r.OrderReviews).HasForeignKey(r => r.ReviewId);
                e.HasOne(e => e.Order).WithMany(r => r.OrderReviews).HasForeignKey(r => r.OrderId);
                
            });
            builder.Entity<RestaurantOrder>(e =>
            {
                e.HasKey(e => new { e.OrderId, e.RestaurantId });
                e.HasOne(e => e.Restaurant).WithMany(r => r.RestaurantOrder).HasForeignKey(r => r.RestaurantId);
                e.HasOne(e => e.Order).WithMany(r => r.RestaurantOrder).HasForeignKey(r => r.OrderId);
            });
            OnModelCreatingPartial(builder);
            builder.Seed(); // seeden van testdata
        }

        //seeden van roles
        public void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            //add admin role
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole Role = new IdentityRole
                {
                    Name="Admin",
                    NormalizedName = "admin"
                };

                IdentityResult result = roleManager.CreateAsync(Role).Result;


            }
            //add customer role
            if (roleManager.FindByNameAsync("Customer").Result == null)
            {
                IdentityRole Role = new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "customer"
                };
                IdentityResult result = roleManager.CreateAsync(Role).Result;
            }
        }
        //seeden van users
        public void SeedUsers(UserManager<IdentityUser> userManager)
        {
            //add admin "Docent@howest.be"
            if (userManager.FindByEmailAsync("docent@howest.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "docent@howest.com",
                    Email = "docent@howest.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Docent@1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
            //add customer "testuser"
            if (userManager.FindByEmailAsync("test@howest.be").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "testuser",
                    Email = "test@howest.be"
                };

                IdentityResult result = userManager.CreateAsync(user, "Test@1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Customer").Wait();
                }
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
