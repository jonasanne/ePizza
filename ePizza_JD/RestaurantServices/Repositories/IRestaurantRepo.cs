using ePizza_JD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantServices.Repositories
{
    public interface IRestaurantRepo
    {
        Task<IEnumerable<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant> GetRestaurantByIdAsync(Guid Id);

        //is dit nodig?
        //Task<Restaurant> UpdateRestaurantWithOrders(Restaurant restaurant);
    }
}
