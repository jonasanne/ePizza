﻿using ePizza_JD.Models;
using MongoDB.Driver;
using RestaurantServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantServices.Data
{
    public class RestaurantServicesContext
    {
        public IMongoDatabase Database;
        public RestaurantServicesContext(IMongoSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionStringLive);
            Database = client.GetDatabase(settings.DatabaseName);
        }
        //namen van collecties zijn casesensitive !!!
        public IMongoCollection<Restaurant> Restaurants => Database.GetCollection<Restaurant>("restaurants");
        public IMongoCollection<Review> Reviews => Database.GetCollection<Review>("reviews");


    }

}
