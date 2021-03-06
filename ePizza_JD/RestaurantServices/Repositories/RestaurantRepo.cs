﻿using ePizza_JD.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using RestaurantServices.Data;
using RestaurantServices.Models;
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
        public async Task<Restaurant> Get(string id)
        {
            //zoek zowel op het BsonId als het RestaurantId (case sensitive)
            ObjectId bsonId = (!ObjectId.TryParse(id, out bsonId)) ? ObjectId.Empty : ObjectId.Parse(id);
            //guid convertie returnt lower chars!!! Guids met hoofdletters worden hierdoor niet gevonden.      
            Guid restaurantId = (!Guid.TryParse(id, out restaurantId)) ? Guid.Empty : Guid.Parse(id);

            var query = context.Restaurants.Find(r => r.RestaurantId == restaurantId); //cursor
            Restaurant restoEntity = await query.FirstOrDefaultAsync<Restaurant>();
            return restoEntity;
        }

        public async Task<IEnumerable<Review>> GetReviewsForRestaurant(string id)
        {
            var objId = new Guid(id);
            var reviews = await context.Reviews.Find(b => b.RestaurantID == objId).ToListAsync<Review>();
            return reviews;
        }

        public IEnumerable<Restaurant> RestaurantJoinedWithReviews()
        {
            var resultTyped = context.Restaurants.Aggregate()
           //Lookup <PK type bij start, FK Type, resultaat type kan ook een Bsondoc zijn>
           .Lookup<Restaurant, Review, Restaurant>(context.Reviews,
             res => res.RestaurantId,   //link FROM restaurant...
             d => d.RestaurantID,  //link TO  review...                                               
             res => res.Reviews) //return (of een arr. result : res => res["Reviews"])
           .ToEnumerable();

            return resultTyped;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsByName(string name)
        {
            var query = context.Restaurants.Find(r => r.Name.ToLower().Contains(name.ToLower()));
            IEnumerable<Restaurant> restoEntities = await query.ToListAsync<Restaurant>();
            return restoEntities;
        }
        //CREATE
        public async Task<Restaurant> CreateAsync(Restaurant restaurant)
        {
            //Gebruik van context acties op de IMongoCollecties
            await context.Restaurants.InsertOneAsync(restaurant);
            return restaurant;
        }

        //UPDATE -------------------------------
        public async Task<Restaurant> UpsertAsync(Restaurant restaurant)
        {
            //upsert = aanmaken indien onbestaand.
            //bijna alle lambda methodes hebben als arg een "options" parameter.
            ReplaceOptions options = new ReplaceOptions { IsUpsert = true }; //upsert
            await context.Restaurants.ReplaceOneAsync<Restaurant>(r => r.RestaurantId == restaurant.RestaurantId, restaurant, options);
            //var restaurantConfirmed = Get(restaurant.RestaurantId.ToString()).Result;
            return restaurant;
        }
        //UPDATE -------------------------------------------------------------
        public async Task<Restaurant> ReplaceAsync(string id, Restaurant restaurant)
        {
            //gebruikt ReplaceOneAsync als variante op UpdateOneAsync()            
            await context.Restaurants.ReplaceOneAsync(r => r.RestaurantId == restaurant.RestaurantId, restaurant);
            //var restaurantConfirmed = Get(restaurant.RestaurantId).Result;
            return restaurant;
        }

        //HARD DELETE----------------------------
        public async Task<string> RemoveAsync(string id)
        {
            ObjectId bsonId = (!ObjectId.TryParse(id, out bsonId)) ? ObjectId.Empty : ObjectId.Parse(id);
            Guid restaurantId = (!Guid.TryParse(id, out restaurantId)) ? Guid.Empty : Guid.Parse(id);

            await context.Restaurants.DeleteOneAsync(r => r.RestaurantId == restaurantId);
            return id;
        }

        //Helpers ------------------------------------------- 
        public async Task<bool> CollectionExistsAsync(string restaurantName)
        {
            var restaurant = await context.Restaurants.Find(r => r.Name == restaurantName).FirstOrDefaultAsync<Restaurant>();
            return restaurant != null;
        }


    }
}
