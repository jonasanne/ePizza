using RestaurantServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantServices.Repositories
{
    public interface IReviewRepo
    {
        Task<Review> CreateAsync(Review restaurant);
        Task<IEnumerable<Review>> GetAll();
    }
}