using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CartServices.Models;

namespace CartServices.Data
{
    public partial class CartServicesContext : DbContext
    {
        public CartServicesContext (DbContextOptions<CartServicesContext> options)
            : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Cart>(e =>
            {
                e.HasKey(e => e.CartId);
                e.Property(e => e.CustomerId).IsRequired();
                e.Property(e => e.OrderType).IsRequired();
                e.HasMany(e => e.CartItems);

            });
            builder.Entity<CartItem>(e =>
            {
                e.HasKey(e => e.ItemId);
                e.Property(e => e.PizzaPrice).IsRequired();
                e.Property(e => e.PizzaName).IsRequired();
                e.Property(e => e.PizzaType).IsRequired();
                e.Property(e => e.Quantity).IsRequired();
                e.Property(e => e.Size).IsRequired();
                e.HasOne(e => e.Cart);

            });

            OnModelCreatingPartial(builder);
            builder.Seed();
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
