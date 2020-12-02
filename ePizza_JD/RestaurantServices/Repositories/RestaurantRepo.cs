using ePizza_JD.Models;
using MongoDB.Driver;
using RestaurantServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantServices.Repositories
{
    public class RestaurantRepo : IRestaurantRepo
    {
        private readonly RestaurantServicesContext context;

        public RestaurantRepo(RestaurantServicesContext context)
        {
            this.context = context;
        }

        //READ
        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            try
            {
                //1. docs ophalen als entiteiten
                IMongoCollection<Restaurant> collection = context.Database.GetCollection<Restaurant>("restaurants"); //case sensitive 

                //korter: context.Restaurants

                //2. docs bevragen, converteren en returnen
                //noot: alle mongo methodes bestaan synchroon en asynchroon
                var result = await collection.Find(FilterDefinition<Restaurant>.Empty).ToListAsync<Restaurant>();
                //3. Return resultaat van <IEnumerable<Restaurant>>
                return result;
            }
            catch (Exception exc)
            {

                throw exc;
            }



        }

        //CREATE
        public async Task<Restaurant> CreateAsync(Restaurant restaurant)
        {
            //Gebruik van context acties op de IMongoCollecties
            await context.Restaurants.InsertOneAsync(restaurant);
            return restaurant;
        }
        //UPDATE

        //DELETE
        public async Task<bool> CollectionExistsAsync(string restaurantName)
        {
            var restaurant = await context.Restaurants.Find(r => r.Name == restaurantName).FirstOrDefaultAsync<Restaurant>();
            return restaurant != null;
        }


    }
}
