using ePizza_JD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantServices.Repositories
{
    public interface IRestaurantRepo
    {
        Task<bool> CollectionExistsAsync(string restaurantName);
        Task<Restaurant> CreateAsync(Restaurant restaurant);
        Task<IEnumerable<Restaurant>> GetAll();
    }
}