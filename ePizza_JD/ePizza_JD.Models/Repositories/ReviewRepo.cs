using ePizza_JD.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza_JD.Models.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly ApplicationDbContext context;

        public ReviewRepo(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<Review> AddReview(Review review)
        {
            try
            {
                review.ReviewId = Guid.NewGuid();
                var result = context.Reviews.AddAsync(review);//ChangeTracking
                await context.SaveChangesAsync();
                return review; //heeft nu een id (autoidentity)
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task DeleteReview(Guid id)
        {
            try
            {
                Review Review = await GetReviewByIdAsync(id);
                if (Review != null)
                {
                    var result = context.Reviews.Remove(Review);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
            }
        }

        public Task<Review> GetReviewByIdAsync(Guid Id)
        {
            try
            {
                return context.Reviews.FirstOrDefaultAsync<Review>(e => e.ReviewId == Id);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            try
            {
                return await context.Reviews.OrderBy(n => n.Date).ToListAsync();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        public async Task<Review> UpdateReview(Review review)
        {
            try
            {
                context.Reviews.Update(review);
                await context.SaveChangesAsync();
                return review;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                throw null;
            }
        }
    }
}
