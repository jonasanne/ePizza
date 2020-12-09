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
using AutoMapper;
using System.Security.Claims;

namespace CartServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartServicesContext _context;
        private readonly ICartRepo cartRepo;
        private readonly IMapper mapper;

        private readonly Guid TESTUSERID = ModelBuilderExtensions.TESTUSERID; // enkel in dev

        public CartsController(CartServicesContext context, ICartRepo cartRepo, IMapper mapper)
        {
            _context = context;
            this.cartRepo = cartRepo;
            this.mapper = mapper;
        }

        // GET: api/Carts?c=Guid
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<CartItemDTO>> Get([FromQuery(Name = "c")] Guid cartId, [FromQuery(Name ="u")] Guid userId)
        {
            userId = TESTUSERID;
            if (cartId == null || cartId == Guid.Empty) // kan 0000 zijn
            { 
                return BadRequest(new { Message = $"cartid :{cartId} niet ingevuld." });
            }
            IList<Claim> lstClaims = this.User.Claims.Cast<Claim>().ToList();
            //IDentityServices plaatst data in this.user.claims (IEnumerable<CLaim>)
            //rede: UserManager kan maar vraagt  (zeker bij customising) ontdubbeling
            if(userId == null || userId == Guid.Empty)
            {
                string userName = this.User.Claims.ElementAt(0).Value;
                userName = lstClaims[0].Value;
                string extraKey = lstClaims.ElementAt(2).Value;
                Claim extraClaimObj = this.User.Claims.Where(c => c.Type == "myExtraKey").FirstOrDefault();
                var thisUserId = User.FindFirst(ClaimTypes.NameIdentifier);
                var thisUserEmail = User.FindFirst(ClaimTypes.Email);

                string role = lstClaims[3].Value;
                userId = Guid.Parse(lstClaims[3].Value);
            }
            else
            {
                var thisUserId = Guid.Parse(lstClaims[3].Value);

                if(userId != thisUserId)
                {
                    return BadRequest(new { Message = $"User :{userId} niet correct." });
                }
            }

            var cartItems = await cartRepo.GetCartItems(cartId); //async!
            var cartDTO = mapper.Map<IEnumerable<CartItemDTO>>(cartItems);
            return Ok(cartDTO);

        }
        

        // GET: api/carts/customer?u=Guid
        [HttpGet("customer/")]
        public async Task<ActionResult<CartDTO>> GetCartsByCustomer([FromQuery(Name = "u")] Guid id)
        {
            if (id == null || id == Guid.Empty) // kan 0000 zijn
            { 
                return BadRequest(new { Message = $"User {id} niet ingevuld." });
            }
            var carts = await cartRepo.GetCartsByUser(id); //async!
            var cartsDTO = mapper.Map<IEnumerable<CartDTO>>(carts);

            return Ok(cartsDTO);

        }

        // POST: api/Carts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart([FromQuery(Name = "u")] Guid userId, [FromBody][Bind("OrderType, CustomerId, CartItems, TimeToPrepare")] Cart cart)
        {
            //TODO: error checks
            if (userId == null || userId == Guid.Empty) // kan 0000 zijn
            {
                return BadRequest(new { Message = $"User {userId} niet ingevuld." });
            }
            if(cart == null)
            {
                return BadRequest(new { Message = $"Geen geldig cart meegegeven" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await cartRepo.CreateCartWithItems(userId,cart);
                return NoContent();
            }
            catch (Exception ex)
            {
                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"het toevoegen van cart met id: {cart.CartId} is niet gelukt."
                });
            }

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
