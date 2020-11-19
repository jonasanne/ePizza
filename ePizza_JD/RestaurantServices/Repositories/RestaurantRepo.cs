using ePizza_JD.Models;
using ePizza_JD.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantServices.Repositories
{
    public class RestaurantRepo : GenericRepo<Restaurant>, IRestaurantRepo
    {
        private readonly RestaurantServicesDbContext context;

        public RestaurantRepo(RestaurantServicesDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> CountRestaurants() => await context.Restaurant.CountAsync();


        public Task<Restaurant> GetRestaurantByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            return await context.Restaurant.OrderBy(e => e.RestaurantName).Include(r => r.Orders).ToListAsync();
        }


    }
}
