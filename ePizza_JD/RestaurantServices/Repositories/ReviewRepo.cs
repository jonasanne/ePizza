using MongoDB.Driver;
using RestaurantServices.Data;
using RestaurantServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantServices.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly RestaurantServicesContext context;

        public ReviewRepo(RestaurantServicesContext context)
        {
            this.context = context;
        }
        //READ
        public async Task<IEnumerable<Review>> GetAll()
        {
            try
            {
                //1. docs ophalen als entiteiten
                IMongoCollection<Review> collection = context.Database.GetCollection<Review>("reviews"); //case sensitive 

                //korter: context.Reviews

                //2. docs bevragen, converteren en returnen
                //noot: alle mongo methodes bestaan synchroon en asynchroon
                var result = await collection.Find(FilterDefinition<Review>.Empty).ToListAsync<Review>();
                //3. Return resultaat van <IEnumerable<Restaurant>>
                return result;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        //CREATE
        public async Task<Review> CreateAsync(Review review)
        {
            //Gebruik van context acties op de IMongoCollecties
            await context.Reviews.InsertOneAsync(review);
            return review;
        }
        //UPDATE

        //DELETE


    }
}
