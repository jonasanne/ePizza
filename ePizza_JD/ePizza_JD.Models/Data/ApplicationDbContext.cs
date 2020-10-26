using System;
using System.Collections.Generic;
using System.Text;
using ePizza_JD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ePizza_JD.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
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
            });
            builder.Entity<PizzaToppings>(e =>
            {
                e.HasKey(e => new { e.PizzaId, e.ToppingId });
            });
            builder.Entity<OrderReviews>(e =>
            {
                e.HasKey(e => new { e.OrderId, e.ReviewId });
            });
            builder.Entity<RestaurantOrder>(e =>
            {
                e.HasKey(e => new { e.OrderId, e.RestaurantId });
            });



        }
    }
}
