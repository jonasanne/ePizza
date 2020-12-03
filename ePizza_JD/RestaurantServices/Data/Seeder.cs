using ePizza_JD.Models;
using MongoDB.Driver;
using RestaurantServices.Models;
using RestaurantServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantServices.Data
{
    public class Seeder
    {
        private readonly IRestaurantRepo restaurantRepo;
        private readonly IReviewRepo reviewRepo;
        private readonly RestaurantServicesContext context;

        private List<Restaurant> Lst_Restaurants = new List<Restaurant>()
        {
        new Restaurant()
        {
            RestaurantId = Guid.Parse("65378dd6-51e3-47a0-92a5-39bf6ffba22c"),
            Description = "Italiaans restaurant",
            HouseNumber = "370",
            Main_city_name ="Brugge",
            PostalCode = "8000",
            Street = "Lange Elzenstraat 370",
            Name= "pizza italia",
            Phone1 = "0487 20 98992",
            Lat =  60,
            Long = 55
        },
        new Restaurant()
        {
            RestaurantId = Guid.Parse("123a658b-7a21-4754-88fb-da1cbd832797"),
            Description = "Restaurant die ook pizza's serveert.",
            HouseNumber = "97",
            Main_city_name ="Oostende",
            PostalCode = "8400",
            Street = "koornstraat",
            Name= "Passione",
            Phone1 = "0471 47 12228",
            Lat =  62,
            Long = 57
        },
        new Restaurant()
        {
            RestaurantId = Guid.Parse("7047db2c-668a-4903-84cd-de077e769bcc"),
            Description = "",
            HouseNumber = "435",
            Main_city_name ="Koksijde",
            PostalCode = "8670",
            Street = "Netelaan",
            Name= "Il Trullo",
            Phone1 = "0472 97 98959",
            Lat =  58,
            Long = 51
        },
        
        };
        //Instantie oproepen vanuit Startup>> configure , met registratie in ConfigureServices.

        public List<Guid> Lst_RestaurantGuids { get; set; } = new List<Guid>();
        public Seeder(IRestaurantRepo restaurantRepo, IReviewRepo reviewRepo, RestaurantServicesContext context)
        {
            this.restaurantRepo = restaurantRepo;
            this.reviewRepo = reviewRepo;
            this.context = context;
        }

        public void initDatabase()
        {
            Console.WriteLine("Seeding Mongodb with restaurants and reviews");

            //geen data blijven toevoegen (MongoDB.Driver)
            try
            {
                //2. testRestaurants aanmaken
                foreach (Restaurant r in Lst_Restaurants)
                {
                    Lst_RestaurantGuids.Add(r.RestaurantId);
                    if (!restaurantRepo.CollectionExistsAsync(r.Name).Result)
                    {
                        restaurantRepo.CreateAsync(r);
                    }
                }


                //Guid currentId = Guid.NewGuid();
                //Lst_RestaurantGuids.Add(currentId);


                //3.Reviews toevoegen
                reviewRepo.CreateAsync(new Review
                {
                    Id = new MongoDB.Bson.ObjectId(),
                    RestaurantID = Lst_RestaurantGuids[new Random().Next(Lst_RestaurantGuids.Count)],
                    Subject = "Pricing",
                    Comment = "Too expensive",
                    Quotation = 4.5M

                });
                reviewRepo.CreateAsync(new Review
                {
                    Id = new MongoDB.Bson.ObjectId(),
                    RestaurantID = Lst_RestaurantGuids[new Random().Next(Lst_RestaurantGuids.Count)],
                    Subject = "Location",
                    Comment = "Nice location in beautiful city.",
                    Quotation = 7.2M

                });

                reviewRepo.CreateAsync(new Review
                {
                    Id = new MongoDB.Bson.ObjectId(),
                    RestaurantID = Lst_RestaurantGuids[new Random().Next(Lst_RestaurantGuids.Count)],
                    Subject = "Service",
                    Comment = "Excellent",
                    Quotation = 8.0M
                });


                reviewRepo.CreateAsync(new Review
                {
                    Id = new MongoDB.Bson.ObjectId(),
                    RestaurantID = Lst_RestaurantGuids[new Random().Next(Lst_RestaurantGuids.Count)],
                    Subject = "Location",
                    Comment = "Difficult to find.",
                    Quotation = 5

                });

                reviewRepo.CreateAsync(new Review
                {
                    Id = new MongoDB.Bson.ObjectId(),
                    RestaurantID = Lst_RestaurantGuids[new Random().Next(Lst_RestaurantGuids.Count)],
                    Subject = "Location",
                    Comment = "Beautiful garden and sunny terrace.",
                    Quotation = 6

                });

                reviewRepo.CreateAsync(new Review
                {
                    Id = new MongoDB.Bson.ObjectId(),
                    RestaurantID = Lst_RestaurantGuids[new Random().Next(Lst_RestaurantGuids.Count)],
                    Subject = "Food",
                    Comment = "Excellent BBQ.",
                    Quotation = 8

                });

                //zoekindexen aanmaken op Mongo
                IndexKeysDefinition<Review> keys = "{ RestaurantID: 1 }";
                var indexModel = new CreateIndexModel<Review>(keys);
                context.Reviews.Indexes.CreateOneAsync(indexModel);

                IndexKeysDefinition<Restaurant> Restaurantkeys = "{ RestaurantID: 1 }";
                var indexModelComment = new CreateIndexModel<Restaurant>(Restaurantkeys);
                context.Restaurants.Indexes.CreateOneAsync(indexModelComment);

            }
            catch (Exception exc)
            {
                Console.WriteLine("fout bij het seeden:", exc);
            }
        }

    }
}
