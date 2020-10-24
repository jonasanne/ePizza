using ePizza_JD.WebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ePizza_JD.Models.Data
{
    public static class ApplicationDbContextExtensions
    {
        private static List<Pizza> _pizzas = new List<Pizza>()
        {
            //prijzen
            // + 20% per size
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Margherita",
            Price = 7.7,
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Pepperoni Lovers",
            Price = 8.7,
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Hawaiian",
            Price = 9.5,
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Barbecue Chicken",
            Price = 10.2,
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Hot 'n Spicy",
            Price = 10.2,
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "4 Cheeses",
            Price = 10.9,
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "4 Cheeses",
            Price = 10.9,
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Sausage",
            Price = 10.3,
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Parma",
            Price = 8.1,
            },
            new Pizza{
            PizzaId = Guid.NewGuid(),
            Name= "Barbecue",
            Price = 10.4,
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
                ToppingId = Guid.NewGuid(),
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
                ToppingId = Guid.NewGuid(),
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
            new Topping()
            {
                ToppingId = Guid.NewGuid(),
                Name = "Paprika",
                Price = 1.4,
                
            },



        };

        public async static Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            IdentityResult roleResult;
            string[] roleNames = { "Admin", "Customer" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }

            }
        }
        public async static Task SeedUsersAsync(UserManager<IdentityUser> userManager)
        {
            try
            {
                //admin maken
                if (await userManager.FindByNameAsync("Docent@MCT") == null)
                {
                    var user = new IdentityUser()
                    {
                        Id = "284243cb-2c97-43dc-bb41-ea429ba69c58",
                        UserName = "Docent@MCT",
                        Email = "Docent@MCT"

                    };
                    var userResult = await userManager.CreateAsync(user, "Docent@1");
                    var roleResult = await userManager.AddToRoleAsync(user, "Admin");

                    if (!userResult.Succeeded || !roleResult.Succeeded)
                    {
                        throw new InvalidOperationException("Failed to build user and roles");
                    }

                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
            }


        }

        public async static Task SeedData(this ApplicationDbContext context)
        {
            try
            {
                //add pizzas
                if (!context.Pizzas.Any())
                {
                    Debug.WriteLine("Seeding pizzas");

                    foreach (Pizza pizza in _pizzas)
                    {
                        await context.Pizzas.AddAsync(pizza);
                        await context.SaveChangesAsync();
                    };
                    
                };

                //add toppings
                if (!context.Toppings.Any())
                {
                    Debug.WriteLine("Seeding pizzas");
                    foreach(Topping topping in _toppings)
                    {
                        await context.Toppings.AddAsync(topping);
                        await context.SaveChangesAsync();
                    };

                };

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw new InvalidOperationException("Failed to build data");
            }


        }


    }
}
