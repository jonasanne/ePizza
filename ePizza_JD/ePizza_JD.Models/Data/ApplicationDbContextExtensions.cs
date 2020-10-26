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
        private static List<Customer> _customers = new List<Customer>()
        {
            new Customer()
            {
                CustomerId = Guid.Parse("90a28cce-eb65-4e55-a485-3e26bb6869eb"),
                Name= "Ronald Steenbruggen",
                ZipCode = 8900,
                City = "Ieper",
                StreetName = "Stationsstraat",
                HouseNumber= 373,
                PhoneNumber = "0486 70 71 99"
            },
            new Customer()
            {
                CustomerId = Guid.Parse("691919d7-888f-4ddb-b5cd-83954b2094a9"),
                Name= "Jort Langedijk",
                City = "Brakel",
                ZipCode = 9660,
                StreetName = "Industrieweg",
                HouseNumber= 165,
                PhoneNumber = "0472 56 03 05"
            },
        };
        private static List<Order> _orders = new List<Order>()
        {
            new Order()
            {
                OrderId = Guid.Parse("e68a3f79-ba5a-49f3-95c7-5e38298e7fde"),
                Date= DateTime.Now,
                Time = 30, //minutes
                PizzaId = Guid.Parse("b3117bca-96da-463b-a433-62587fd8bd88"),
                Quantity = 1,
                Size= Order.Sizes.Medium,
                PizzaType=Order.PizzaTypes.Normal,
                OrderType = Order.OrderTypes.delivery
            },
            new Order()
            {
                OrderId = Guid.Parse("bba2eded-d219-4618-b0ce-c3a983772772"),
                Date= DateTime.Now,
                Time = 30, //minutes
                PizzaId = Guid.Parse("6bd07325-bda2-451f-bbcb-3bf1025834c4"),
                Quantity = 1,
                Size= Order.Sizes.Large,
                PizzaType=Order.PizzaTypes.Vegetarian,
                OrderType = Order.OrderTypes.takeaway
            },

        };
        private static List<Review> _reviews = new List<Review>()
        {
            new Review()
            {
                ReviewId = Guid.Parse("c456b9e8-d32c-4d6e-8b32-da50c5edc856"),
                Date= DateTime.Now,
                Title = "Amazing pizza!",
                Rating = 4,
            },
            new Review()
            {
                ReviewId = Guid.Parse("0eae9dca-640f-408e-8aa5-325f40cb3eee"),
                Date= DateTime.Now,
                Title = "Pizzashop online",
                Description = "Fast delivery and amazingly great taste!",
                Rating = 4.5,
            },

        };
        private static List<OrderReviews> _orderReviews = new List<OrderReviews>()
        {
            new OrderReviews()
            {
                ReviewId = Guid.Parse("c456b9e8-d32c-4d6e-8b32-da50c5edc856"),
                OrderId = Guid.Parse("e68a3f79-ba5a-49f3-95c7-5e38298e7fde"),
               
            },
            new OrderReviews()
            {
                ReviewId = Guid.Parse("0eae9dca-640f-408e-8aa5-325f40cb3eee"),
                OrderId = Guid.Parse("bba2eded-d219-4618-b0ce-c3a983772772"),
               
            },

        };
        private static List<CustomerOrders> _customerOrders = new List<CustomerOrders>()
        {
            new CustomerOrders()
            {
               CustomerId =Guid.Parse("90a28cce-eb65-4e55-a485-3e26bb6869eb"),
               OrderId = Guid.Parse("bba2eded-d219-4618-b0ce-c3a983772772")
            },
            new CustomerOrders()
            {
               CustomerId = Guid.Parse("691919d7-888f-4ddb-b5cd-83954b2094a9"),
               OrderId = Guid.Parse("e68a3f79-ba5a-49f3-95c7-5e38298e7fde")
            },

        };
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
                    Debug.WriteLine("Seeding Toppings");
                    foreach(Topping topping in _toppings)
                    {
                        await context.Toppings.AddAsync(topping);
                        await context.SaveChangesAsync();
                    };

                };
                //add Customers
                if (!context.Customers.Any())
                {
                    Debug.WriteLine("Seeding Customers");
                    foreach(Customer Customer in _customers)
                    {
                        await context.Customers.AddAsync(Customer);
                        await context.SaveChangesAsync();
                    };

                };
                //add Orders
                if (!context.Orders.Any())
                {
                    Debug.WriteLine("Seeding Orders");
                    foreach(Order Order in _orders)
                    {
                        await context.Orders.AddAsync(Order);
                        await context.SaveChangesAsync();
                    };

                };
                //add Reviews
                if (!context.Reviews.Any())
                {
                    Debug.WriteLine("Seeding Reviews");
                    foreach(Review Review in _reviews)
                    {
                        await context.Reviews.AddAsync(Review);
                        await context.SaveChangesAsync();
                    };

                };
                //add OrderReviews
                if (!context.OrderReviews.Any())
                {
                    Debug.WriteLine("Seeding orderReviews");
                    foreach(OrderReviews oReview in _orderReviews)
                    {
                        await context.OrderReviews.AddAsync(oReview);
                        await context.SaveChangesAsync();
                    };

                };
                //add CustomerOrders
                if (!context.CustomerOrders.Any())
                {
                    Debug.WriteLine("Seeding orderReviews");
                    foreach(CustomerOrders customerOrder in _customerOrders)
                    {
                        await context.CustomerOrders.AddAsync(customerOrder);
                        await context.SaveChangesAsync();
                    };

                };
                //TODO: add PizzaToppings

                //add restaurants
                if (!context.Restaurants.Any())
                {
                    Debug.WriteLine("Seeding restaurants");
                    foreach (Restaurant resto in _restaurants)
                    {
                        await context.Restaurants.AddAsync(resto);
                        await context.SaveChangesAsync();
                    };

                };


                //TODO : add restaurantOrders




            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException.Message);
                throw new InvalidOperationException("Failed to build data");
            }


        }


    }
}
