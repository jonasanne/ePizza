using ePizza_JD.Models;
using ePizza_JD.WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ePizza_JD.WebApp.Data
{
    public static class ModelBuilderExtensions
    {
        private static List<Restaurant> _restaurants = new List<Restaurant>()
        {
            new Restaurant()
            {
                RestaurantId= Guid.NewGuid(),
                StreetName = "Lange Elzenstraat",
                HouseNumber =  160,
                City= "Brugge",
                PhoneNumber = "0471 32 89746",
                ZipCode= 8200,
                RestaurantName = "The little italian"
            },
            new Restaurant()
            {
                RestaurantId= Guid.NewGuid(),
                StreetName = "Stationsstraat",
                HouseNumber =  351,
                City= "Ieper",
                PhoneNumber = "0491 82 74431",
                ZipCode= 8900,
                RestaurantName = "Pastasciutta"
            },
            new Restaurant()
            {
                RestaurantId= Guid.NewGuid(),
                StreetName = "Herentalsebaan",
                HouseNumber =  399,
                City= "Antwerpen",
                PhoneNumber = "0494 26 36224",
                ZipCode= 2000,
                RestaurantName = "Mamma in cucina"
            },


        };


        public static RestaurantServicesDbContext _context { get; set; }


        public static void Seed(this ModelBuilder modelBuilder)
        {
            Console.WriteLine("Seeding Tables with restaurants");
            modelBuilder.Entity<Restaurant>().HasData(_restaurants);
        }


    }
}
