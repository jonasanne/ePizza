using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartServices.Data;
using CartServices.Models;
using CartServices.Repositories;
using System.Diagnostics;

namespace CartServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartServicesContext _context;
        private readonly ICartRepo cartRepo;

        public CartsController(CartServicesContext context, ICartRepo cartRepo)
        {
            _context = context;
            this.cartRepo = cartRepo;
        }



        // GET: api/Carts?u=Guid
        [HttpGet]
        public async Task<ActionResult<Cart>> Get([FromQuery(Name = "u")] Guid id)
        {
            if (id == null || id == Guid.Empty) // kan 0000 zijn
            { 
                return BadRequest(new { Message = $"User {id} niet ingevuld." });
            }
            var cartItems = await cartRepo.GetCartItems(id); //async!
            return Ok(cartItems);
    }

        // PUT: api/Carts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart([FromQuery(Name = "u")] Guid userId, [FromBody] CartItem cartItem)
        {
            //TODO LATER UITWERKEN
            return null;
        }

        // POST: api/Carts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart([FromQuery(Name = "u")] Guid userId, [FromBody] CartItem cartItem)
        {

            //TODO: error checks
            if (userId == null || userId == Guid.Empty) // kan 0000 zijn
            {
                return BadRequest(new { Message = $"User {userId} niet ingevuld." });
            }
            if(cartItem == null)
            {
                return BadRequest(new { Message = $"Geen geldig cartItem meegegeven" });

            }
            await cartRepo.InsertCartItem(userId, cartItem);
            return new OkResult();
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cart>> DeleteCart([FromQuery(Name ="u")] Guid userId, [FromQuery(Name ="ci")] Guid cartItemId)
        {

            if (cartItemId == null || cartItemId == Guid.Empty) // kan 0000 zijn
            {
                return BadRequest(new { Message = $"geen cart item aanwezig" });
            }
            if (userId == null || userId == Guid.Empty) // kan 0000 zijn
            {
                return BadRequest(new { Message = $"geen user meegegeven" });
            }
            var items = cartRepo.GetCartItems(userId);

            return null;
        }

        private bool CartExists(Guid id)
        {
            return _context.Carts.Any(e => e.CartId == id);
        }
    }
}
