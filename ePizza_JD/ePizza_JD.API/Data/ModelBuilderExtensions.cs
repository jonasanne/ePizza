using ePizza_JD.WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ePizza_JD.Models.Data
{
    public static class ModelBuilderExtensions
    {
        private static List<Pizza> _pizzas = new List<Pizza>()
        {
            //prijzen
            // + 20% per size
            new Pizza{
            PizzaId = Guid.Parse("b3117bca-96da-463b-a433-62587fd8bd88"),
            Name= "Margherita",
            Price = 7.7,
            ImgUrl="https://cdn-catalog.pizzahut.be/images/be/20170830150056964.jpg"
            },
            new Pizza{
            PizzaId = Guid.Parse("6bd07325-bda2-451f-bbcb-3bf1025834c4"),
            Name= "Pepperoni Lovers",
            Price = 8.7,
            ImgUrl= "https://cdn-catalog.pizzahut.be/images/be/20170830150118476.jpg"
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Hawaiian",
            Price = 9.5,
            ImgUrl="https://cdn-catalog.pizzahut.be/images/be/20170830145952504.jpg"
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Barbecue Chicken",
            Price = 10.2,
            ImgUrl="https://cdn-catalog.pizzahut.be/images/be/20170830145601044.jpg"
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Hot 'n Spicy",
            Price = 10.2,
            ImgUrl = "https://cdn-catalog.pizzahut.be/images/be/20170830150015440.jpg"
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "4 Cheeses",
            Price = 10.9,
            ImgUrl="https://cdn-catalog.pizzahut.be/images/be/20170830145444334.jpg"
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Tuna",
            Price = 9.4,
            ImgUrl="https://cdn-catalog.pizzahut.be/images/be/20171229145324596.jpg"
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Forestiere",
            Price = 10.3,
            ImgUrl="https://cdn-catalog.pizzahut.be/images/be/20170830145855396.jpg"
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Parma",
            Price = 8.1,
            ImgUrl="https://cdn-catalog.pizzahut.be/images/be/20170830145618975.jpg"
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Barbecue",
            Price = 10.4,
            ImgUrl="https://cdn-catalog.pizzahut.be/images/be/20170830145527344.jpg"
            },
        };
        private static List<Topping> _toppings = new List<Topping>()
        {
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Ham",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Mozzarella",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Pepperoni",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Champignons",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Pineapple",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Chilipepper",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Red onion",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Grilled Chicken",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Barbecue sauce",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.Parse("16a1fa18-101d-4f91-ba66-561e6bd8331b"),
                Name = "Tomato Sauce",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Pork",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.Parse("3e153375-e8aa-4c4b-8836-c69213111eb0"),
                Name = "Emmental",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Goat cheese",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Gorgonzola",
                Price = 1.4,

            },
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Paprika",
                Price = 1.4,

            },




        };
        private static List<PizzaToppings> _pizzaToppings = new List<PizzaToppings>()
        {
            new PizzaToppings()
            {
                PizzaId = Guid.Parse("b3117bca-96da-463b-a433-62587fd8bd88"),
                ToppingId = Guid.Parse("16a1fa18-101d-4f91-ba66-561e6bd8331b"),
                ToppingName ="Tomato Sauce"
            },
            new PizzaToppings()
            {
                PizzaId = Guid.Parse("b3117bca-96da-463b-a433-62587fd8bd88"),
                ToppingId = Guid.Parse("3e153375-e8aa-4c4b-8836-c69213111eb0"),
                ToppingName= "Emmental"
            },

        };


        public static PizzaServiceDbContext _context { get; set; }


        public static void Seed(this ModelBuilder modelBuilder)
        {
            Console.WriteLine("Seeding Tables");
            modelBuilder.Entity<Pizza>().HasData(_pizzas);
            modelBuilder.Entity<Topping>().HasData(_toppings);
            modelBuilder.Entity<PizzaToppings>().HasData(_pizzaToppings);
        }


    }
}
