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
    public partial class PizzaServiceDbContext :DbContext
    {
        public PizzaServiceDbContext()
        {

        }

        public PizzaServiceDbContext(DbContextOptions<PizzaServiceDbContext> options)
            : base(options)
        {
        }
        //create tables
        public virtual DbSet<Pizza> Pizzas  { get; set; }
        public virtual DbSet<Topping> Toppings  { get; set; }
        public virtual DbSet<PizzaToppings> PizzaToppings { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }




        //fluent api
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Pizza>(e =>
            {
                e.HasKey(e => e.PizzaId);
                e.Property(e => e.Name).IsRequired();
                e.Property(e => e.Price).IsRequired();
                e.HasMany(e => e.Reviews).WithOne(e => e.Pizza);
            });
            builder.Entity<Review>(e =>
            {
                e.HasKey(e =>e.ReviewId);
                e.HasOne(e => e.Pizza).WithMany(e => e.Reviews);
            });

            builder.Entity<PizzaToppings>(e =>
            {
                e.HasKey(e => new { e.PizzaId, e.ToppingId });
                e.HasOne(e => e.Topping).WithMany(m => m.PizzaToppings).HasForeignKey(m => m.ToppingId);
                e.HasOne(e => e.Pizza).WithMany(m => m.PizzaToppings).HasForeignKey(m => m.PizzaId);
            });

            


            OnModelCreatingPartial(builder);
            builder.Seed(); // seeden van testdata
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
