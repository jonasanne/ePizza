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
using System.Net;

namespace ePizza_JD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenericRepo<Topping> genericRepo;
        private readonly IMapper mapper;

        public ToppingsController(ApplicationDbContext context, IGenericRepo<Topping> genericRepo, IMapper mapper)
        {
            _context = context;
            this.genericRepo = genericRepo;
            this.mapper = mapper;
        }

        // GET: api/Toppings
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ToppingDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ToppingDTO>>> GetToppings()
        {
            try
            {

                var toppings = await genericRepo.GetAllAsync();
                var toppingDTOs = mapper.Map<IEnumerable<ToppingDTO>>(toppings);

                return Ok(toppingDTOs);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Topping/5
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ToppingDTO), (int)HttpStatusCode.OK)]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ToppingDTO>> GetToppingById(Guid id)
        {
            var toppings = await genericRepo.GetByExpressionAsync(m => m.ToppingId == id);

            // Vergeet de count niet! categories is een collectie en nooit null
            if (toppings == null || toppings.Count() == 0)
            {
                return NotFound(new { message = "Topping niet gevonden." });
                //return NotFound();
            }
            Topping topping = toppings.FirstOrDefault<Topping>();
            return Ok(mapper.Map<ToppingDTO>(topping));
        }

        // GET: api/Topping/Name/barbecue
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ToppingDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("name/{name}", Name = "GetToppingByName")]
        public async Task<ActionResult<ToppingDTO>> GetToppingByName(string name)
        {

            if (name == null)
            {
                return BadRequest(new { message = "Ongeldige naam ingevoerd." });
            }

            var toppings = await genericRepo.GetByExpressionAsync(m => m.Name.Contains(name));
            if (toppings == null || toppings.Count() == 0)
            {
                return NotFound(new { message = "Topping niet gevonden." });
                //return NotFound();
            }
            Topping category = toppings.FirstOrDefault<Topping>();

            return Ok(mapper.Map<ToppingDTO>(category));
        }



        // PUT: api/Toppings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopping(Guid id, ToppingDTO toppingDTO)
        {
            if (id != toppingDTO.Id || toppingDTO == null)
            {
                return BadRequest();
            }

            //2. mapping
            var topping = mapper.Map<Topping>(toppingDTO);
            if (topping == null)
            {
                return BadRequest(new { Messsage="Onvoldoende data bij de topping" });
            }

            //3. Validatie
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Messsage=$"Geen geldige input. {ModelState}" });

            }
            
            try
            {
                Topping toppingSearch = (await genericRepo.GetByExpressionAsync(c => c.ToppingId == toppingDTO.Id)).FirstOrDefault();
                await genericRepo.Update(mapper.Map<Topping>(toppingDTO), id);
                //return Ok(new { Message = $"Topping with name: {topping.Name} has been Correctly updated" });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!genericRepo.Exists(topping, id).Result)

                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction("HandleErrorCode", "Error", new
                    {
                        statusCode = 400,
                        errorMessage = $"De Topping met naam: '{topping.Name}' werd niet aangepast."
                    });
                }
            }

            return NoContent();
        }

        // POST: api/Toppings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<ActionResult<ToppingDTO>> PostTopping([FromBody] [Bind("Name")]   ToppingDTO toppingDTO)
        {
            if (toppingDTO == null)
            {
                return BadRequest(new { Message = "Geen categorie input" });
            };

            var topping = mapper.Map<Topping>(toppingDTO);
            if (topping == null)
            {
                return BadRequest(new { Message = "Onvoldoende data bij de topping" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await genericRepo.Create(topping);
                return CreatedAtAction(nameof(GetToppingById), new { id = topping.ToppingId }, mapper.Map<ToppingDTO>(topping));
            }
            catch (Exception exc)
            {

                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Het bewaren van topping met naam: '{topping.Name}' is mislukt."
                });
            }
        }

        // DELETE: api/Toppings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Topping>> DeleteTopping(Guid id)
        {
            var toppings = await genericRepo.GetByExpressionAsync(c => c.ToppingId == id);
            if (toppings == null || toppings.Count() == 0)
            {
                return NotFound(new { message = "Topping niet gevonden." });
            }

            Topping topping = toppings.FirstOrDefault<Topping>();
            try
            {

                await genericRepo.Delete(topping);

            }
            catch
            {
                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Het verwijderen van Topping met naam: '{topping.Name}' is mislukt."
                });

            }

            return Ok(mapper.Map<ToppingDTO>(topping));
        }

        private bool ToppingExists(Guid id)
        {
            return _context.Toppings.Any(e => e.ToppingId == id);
        }
    }
}
