using CartServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartServices.Data
{
    public static class ModelBuilderExtensions
    {
        public static Microsoft.AspNetCore.Hosting.IWebHostEnvironment env { get; set; }

        //"ccbea8c0-7b9a-4ad9-901c-98e9f30daf40"
        public static Guid TESTUSERID = Guid.Parse("ccbea8c0-7b9a-4ad9-901c-98e9f30daf40");
        //Static Testdata
        private readonly static List<Cart> _carts = new List<Cart> {
            new Cart
            {
                CartId = Guid.Parse("dd49fe42-f48e-42f6-9cc6-013341982f7a"),
               CustomerId  = TESTUSERID,
               OrderType =OrderTypes.delivery,
               TimeToPrepare = 35,
            }
        };

        private readonly static List<CartItem> _cartItems = new List<CartItem>
        {
            new CartItem()
            {
             CartId= Guid.Parse("dd49fe42-f48e-42f6-9cc6-013341982f7a"),
             ItemId = Guid.Parse("b3117bca-96da-463b-a433-62587fd8bd88"),
             PizzaName = "Margherita",
             PizzaPrice = 7.7,
             PizzaType = PizzaTypes.Normal,
             Quantity = 1,
             Size = Sizes.Medium
            },
            new CartItem()
            {
             CartId= Guid.Parse("dd49fe42-f48e-42f6-9cc6-013341982f7a"),
             ItemId = Guid.Parse("6bd07325-bda2-451f-bbcb-3bf1025834c4"),
             PizzaName = "Pepperoni Lovers",
             PizzaPrice = 8.7,
             PizzaType = PizzaTypes.Vegetarian,
             Quantity = 1,
             Size = Sizes.Large
            },

        };


        public static CartServicesContext _context { get; set; }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            Console.WriteLine("Seeding Cart and CartItems for testing");
            modelBuilder.Entity<Cart>().HasData(_carts);
            modelBuilder.Entity<CartItem>().HasData(_cartItems);
        }




        public static string UserId
        {
            get
            {
                if (env.EnvironmentName != "Production")
                {
                    return TESTUSERID.ToString();
                }
                else
                {
                    return null;
                }
            }
        }


    }
}
