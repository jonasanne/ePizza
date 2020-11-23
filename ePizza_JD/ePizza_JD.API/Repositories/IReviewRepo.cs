using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ePizza_JD.Models.Repositories
{
    public interface IReviewRepo
    {
        Task<IEnumerable<Review>> GetReviewsAsync();
        Task<Review> GetReviewByIdAsync(Guid Id);
        Task<Review> AddReview(Review review);
        Task DeleteReview(Guid id);
        Task<Review> UpdateReview(Review review);

    }
}
