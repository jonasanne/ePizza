using ePizza_JD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantRepo restaurantRepo;

        public RestaurantsController(RestaurantRepo restaurantRepo)
        {
            this.restaurantRepo = restaurantRepo;
        }


        [HttpGet]
        [Route("api/restaurants")]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {

            var restos = await restaurantRepo.GetAll();
            return Ok(restos);

        }

    }
}
