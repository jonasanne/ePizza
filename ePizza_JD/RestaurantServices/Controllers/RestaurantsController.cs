using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ePizza_JD.Models;
using AutoMapper;
using System.Net;
using ePizza_JD.WebApp.Data;
using RestaurantServices.Repositories;

namespace ePizza_JD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantServicesDbContext _context;
        private readonly IMapper mapper;
        private readonly IGenericRepo<Restaurant> genericRepo;
        private readonly IRestaurantRepo restaurantRepo;

        public RestaurantsController(RestaurantServicesDbContext context, IMapper mapper, IGenericRepo<Restaurant> genericRepo, IRestaurantRepo restaurantRepo)
        {
            _context = context;
            this.mapper = mapper;
            this.genericRepo = genericRepo;
            this.restaurantRepo = restaurantRepo;
        }

        // GET: api/Restaurants
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Restaurant>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            try
            {

                var restaurants = await restaurantRepo.GetRestaurantsAsync();
                //var restaurantDTOs = mapper.Map<IEnumerable<RestaurantDTO>>(restaurants);

                return Ok(restaurants);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Restaurants/5
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RestaurantDTO), (int)HttpStatusCode.OK)]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<RestaurantDTO>> GetRestaurantById(Guid id)
        {
            var Restaurants = await genericRepo.GetByExpressionAsync(m => m.RestaurantId == id);

            // Vergeet de count niet! Restaurant is een collectie en nooit null
            if (Restaurants == null || Restaurants.Count() == 0)
            {
                return NotFound(new { message = "Restaurant niet gevonden." });
                //return NotFound();
            }
            Restaurant restaurant = Restaurants.FirstOrDefault<Restaurant>();
            return Ok(mapper.Map<RestaurantDTO>(restaurant));

        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(Guid id, RestaurantDTO restaurantDTO)
        {
            if (id != restaurantDTO.Id || restaurantDTO == null)
            {
                return BadRequest();
            }

            //2. mapping
            var restaurant = mapper.Map<Restaurant>(restaurantDTO);
            if (restaurant == null)
            {
                return BadRequest(new { Messsage = "Onvoldoende data bij de Restaurant" });
            }

            //3. Validatie
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Messsage = $"Geen geldige input. {ModelState}" });

            }

            try
            {
                Restaurant restaurantSearch = (await genericRepo.GetByExpressionAsync(c => c.RestaurantId == restaurantDTO.Id)).FirstOrDefault();
                await genericRepo.Update(mapper.Map<Restaurant>(restaurantDTO), id);
                //return Ok(new { Message = $"Topping with name: {topping.Name} has been Correctly updated" });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!genericRepo.Exists(restaurant, id).Result)

                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction("HandleErrorCode", "Error", new
                    {
                        statusCode = 400,
                        errorMessage = $"Het Restaurant met naam : '{restaurant.RestaurantName}' werd niet aangepast."
                    });
                }
            }

            return NoContent();
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<ActionResult<RestaurantDTO>> PostRestaurant([FromBody] [Bind("Name")]   RestaurantDTO restaurantDTO)
        {
            if (restaurantDTO == null)
            {
                return BadRequest(new { Message = "Geen Restaurant input" });
            };

            var restaurant = mapper.Map<Restaurant>(restaurantDTO);
            if (restaurant == null)
            {
                return BadRequest(new { Message = "Onvoldoende data bij de Restaurant" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await genericRepo.Create(restaurant);
                return CreatedAtAction(nameof(GetRestaurantById), new { id = restaurant.RestaurantId }, mapper.Map<RestaurantDTO>(restaurant));
            }
            catch (Exception exc)
            {

                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Het bewaren van topping met naam: '{restaurant.RestaurantName}' is mislukt."
                });
            }
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurant>> DeleteRestaurant(Guid id)
        {
            var restaurants = await genericRepo.GetByExpressionAsync(c => c.RestaurantId == id);
            if (restaurants == null || restaurants.Count() == 0)
            {
                return NotFound(new { message = "Restaurant niet gevonden." });
            }

            Restaurant restaurant = restaurants.FirstOrDefault<Restaurant>();
            try
            {

                await genericRepo.Delete(restaurant);

            }
            catch
            {
                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Het verwijderen van Restaurant '{restaurant.RestaurantName}' is mislukt."
                });

            }

            return Ok(mapper.Map<RestaurantDTO>(restaurant));
        }

        private bool RestaurantExists(Guid id)
        {
            return _context.Restaurant.Any(e => e.RestaurantId == id);
        }
    }
}
