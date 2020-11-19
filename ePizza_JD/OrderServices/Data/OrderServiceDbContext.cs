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
    public partial class OrderServiceDbContext : IdentityDbContext
    {
        public OrderServiceDbContext()
        {

        }

        public OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> options)
            : base(options)
        {
        }
        //create tables
        public virtual DbSet<Order> Orders  { get; set; }
        public virtual DbSet<Review> Reviews  { get; set; }
        public virtual DbSet<Customer> Customers  { get; set; }
        //public virtual DbSet<CustomerOrders> CustomerOrders  { get; set; }
        //public virtual DbSet<OrderReviews> OrderReviews  { get; set; }




        //fluent api
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<CustomerOrders>(e =>
            //{
            //    e.HasKey(e => new { e.CustomerId, e.OrderId });
            //    e.HasOne(e => e.Customer).WithMany(m => m.CustomerOrders).HasForeignKey(m => m.CustomerId);
            //    e.HasOne(e => e.Order).WithMany(m => m.CustomerOrders).HasForeignKey(m => m.OrderId);
            //});


            //builder.Entity<OrderReviews>(e =>
            //{
            //    e.HasKey(e => new { e.OrderId, e.ReviewId });
            //    e.HasOne(e => e.Review).WithMany(r => r.OrderReviews).HasForeignKey(r => r.ReviewId);
            //    e.HasOne(e => e.Order).WithMany(r => r.OrderReviews).HasForeignKey(r => r.OrderId);
            //});


            builder.Entity<Order>(e =>
            {
                e.HasOne(e => e.Review).WithOne(e => e.Order);
            });
            builder.Entity<Review>(e =>
            {
                e.HasOne(e => e.Order).WithOne(e => e.Review);
            });



            OnModelCreatingPartial(builder);
            builder.Seed(); // seeden van testdata
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
