using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ePizza_JD.Models;
using ePizza_JD.WebApp.Data;
using System.Diagnostics;
using AutoMapper;
using ePizza_JD.Models.Repositories;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System.Text.Encodings.Web;
using System.Net;

namespace ePizza_JD.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Consumes("application/json", "application/json-path+json", "multipart/form-data", "application/form-data")]
    [Produces("application/json")]
    public class PizzasController : ControllerBase
    {
        private readonly PizzaServiceDbContext _context;
        private readonly IMapper mapper;
        private readonly IPizzaRepo pizzaRepo;
        private readonly IGenericRepo<Pizza> genericRepo;

        public PizzasController(PizzaServiceDbContext context, IMapper mapper, IPizzaRepo pizzaRepo, IGenericRepo<Pizza> genericRepo )
        {
            _context = context;
            this.mapper = mapper;
            this.pizzaRepo = pizzaRepo;
            this.genericRepo = genericRepo;
        }

        // GET: api/Pizzas
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PizzaDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PizzaDTO>>> GetPizzas()
        {
            try
            {
                var pizzas =  await pizzaRepo.GetPizzasAsync();
                var PizzasDTO = mapper.Map<IEnumerable<PizzaDTO>>(pizzas);
                return Ok(PizzasDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Pizzas/5
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(PizzaDTO), (int)HttpStatusCode.OK)]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<PizzaDTO>> GetPizzaById(Guid id)
        {
            Pizza pizza = new Pizza();
            try
            {
                pizza = await pizzaRepo.GetPizzaByGuidAsync(id);
                if (pizza == null)
                {
                    return NotFound();
                }
                
                return Ok(mapper.Map<PizzaDTO>(pizza));
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"expection : {ex}");
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    Statuscode = 400,
                    errorMessage = $"ophalen van de pizza: '{pizza.Name}' is mislukt"
                });
            }
        }

        // PUT: api/Pizzas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(Guid id, PizzaDTO pizzaDTO)
        {
            //1. altijd null check naast supplementaire Id check
            if (id != pizzaDTO.Id || pizzaDTO == null)
            {
                return BadRequest();
            }

            ////2. mapping
            var pizza = mapper.Map<Pizza>(pizzaDTO);
            if (pizza == null)
            {
                return BadRequest(new { Message = "Onvoldoende Data bij de pizza" });

            }

            //3 validatie
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = $"Geen geldige input. {ModelState}" });
                
            }

            try
            {
                Pizza pizzaSearch = (await genericRepo.GetByExpressionAsync(c => c.PizzaId == pizza.PizzaId)).FirstOrDefault();
                await genericRepo.Update(mapper.Map<Pizza>(pizzaDTO), id);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!genericRepo.Exists(pizza, id).Result)

                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction("HandleErrorCode", "Error", new
                    {
                        statusCode = 400,
                        errorMessage = $"De Pizza: '{pizza.Name}' werd niet aangepast."
                    });
                }
            }

            return NoContent();
        }

        // POST: api/Pizzas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<ActionResult<PizzaEditCreateDTO>> PostPizza([FromBody] [Bind("Name,Price,ImgUrl,Toppings")] PizzaEditCreateDTO pizzaDTO)
        {

            if (pizzaDTO == null)
            {
                return BadRequest(new { Message = "Geen Pizza input" });
            };


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                //check if pizza already exists
                //controle als de pizza al bestaat (op naam)
                var pizzaExists = _context.Pizzas.FirstOrDefault(p => p.Name ==pizzaDTO.Name);

                if (pizzaExists == null)
                {

                var pizza = mapper.Map<Pizza>(pizzaDTO);
                ICollection<PizzaToppings> pizzaToppingsList = new List<PizzaToppings>();

                foreach (Topping t in pizzaDTO.Toppings)
                {
                    PizzaToppings pt = new PizzaToppings
                    {
                        PizzaId = pizza.PizzaId,
                        Topping = t,
                        Pizza = pizza,
                        ToppingId = t.ToppingId
                    };

                    pizzaToppingsList.Add(pt);

                    
                }
                pizza.PizzaToppings = pizzaToppingsList;
                await pizzaRepo.PostPizzaWithToppings(pizza);
                return CreatedAtAction(nameof(GetPizzaById), new { id = pizza.PizzaId }, mapper.Map<PizzaDTO>(pizza));
                }


                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Pizza met naam: '{pizzaDTO.Name}' is bestaat al."
                });

            }
            catch (Exception exc)
            {

                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Het bewaren van pizza met naam: '{pizzaDTO.Name}' is mislukt."
                });
            }
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pizza>> DeletePizza(Guid id)
        {
            var pizzas = await genericRepo.GetByExpressionAsync(c => c.PizzaId == id);
            if (pizzas == null || pizzas.Count() == 0)
            {
                return NotFound(new { message = "Pizza niet gevonden." });
            }

            Pizza pizza= pizzas.FirstOrDefault<Pizza>();
            try
            {

                await genericRepo.Delete(pizza);

            }
            catch
            {
                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Het verwijderen van pizza '{pizza.Name}' is mislukt."
                });

            }

            return Ok(mapper.Map<PizzaDTO>(pizza));

        }

        private bool PizzaExists(Guid id)
        {
            return _context.Pizzas.Any(e => e.PizzaId == id);
        }
    }
}
