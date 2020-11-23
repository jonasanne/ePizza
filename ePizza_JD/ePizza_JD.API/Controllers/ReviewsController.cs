using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ePizza_JD.Models;
using ePizza_JD.WebApp.Data;
using AutoMapper;
using ePizza_JD.Models.Repositories;
using PizzaServices.Models;
using System.Net;
using System.Diagnostics;

namespace PizzaServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Consumes("application/json", "application/json-path+json", "multipart/form-data", "application/form-data")]
    [Produces("application/json")]
    public class ReviewsController : ControllerBase
    {
        private readonly PizzaServiceDbContext _context;
        private readonly IMapper mapper;
        private readonly IReviewRepo reviewRepo;
        private readonly IGenericRepo<Review> genericRepo;

        public ReviewsController(PizzaServiceDbContext context, IMapper mapper, IReviewRepo reviewRepo, IGenericRepo<Review> genericRepo)
        {
            _context = context;
            this.mapper = mapper;
            this.reviewRepo = reviewRepo;
            this.genericRepo = genericRepo;
        }

        // GET: api/Reviews
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReviewDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviews()
        {
            try
            {
                var reviews = await reviewRepo.GetReviewsAsync();
                var reviewDTO = mapper.Map<IEnumerable<ReviewDTO>>(reviews);
                return Ok(reviewDTO);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"expection : {ex}");
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    Statuscode = 400,
                    errorMessage = $"ophalen van de reviews mislukt message:{ex}"
                });
            }
        } 

        // GET: api/Reviews/5
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ReviewDTO), (int)HttpStatusCode.OK)]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ReviewDTO>> GetReviewById(Guid id)
        {
            Review review = new Review();
            try
            {
                review = await genericRepo.GetAsyncByGuid(id);
                
                if (review == null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<ReviewDTO>(review));
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"expection : {ex}");
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    Statuscode = 400,
                    errorMessage = $"ophalen van de review met id: '{review.ReviewId}' is mislukt"
                });
            }
        }



        //onmogelijk om een review te updaten
        //// PUT: api/Reviews/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutReview(Guid id, Review review)
        //{
        //    if (id != review.ReviewId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(review).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReviewExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Reviews
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReviewDTO>> PostReview(ReviewDTO reviewDTO)
        {
            if (reviewDTO == null)
            {
                return BadRequest(new { Message = "Geen review input" });
            };


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Review review = mapper.Map<Review>(reviewDTO); 
                await genericRepo.Create(review);
                await genericRepo.SaveAsync();
                return CreatedAtAction(nameof(GetReviewById), new { id = review.ReviewId }, review);
            }
            catch (Exception exc)
            {
                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Het bewaren van review met titel: '{reviewDTO.Title}' is mislukt."
                });
            }
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReviewDTO>> DeleteReview(Guid id)
        {
            var reviews = await genericRepo.GetByExpressionAsync(c => c.ReviewId == id);
            if (reviews == null || reviews.Count() == 0)
            {
                return NotFound(new { message = "review niet gevonden." });
            }

            Review review = reviews.FirstOrDefault<Review>();

            try
            {
                await genericRepo.Delete(review);
            }
            catch
            {
                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Het verwijderen van review met titel '{review.Title}' is mislukt."
                });
            }
            return Ok(mapper.Map<ReviewDTO>(review));

        }

        private bool ReviewExists(Guid id)
        {
            return _context.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
