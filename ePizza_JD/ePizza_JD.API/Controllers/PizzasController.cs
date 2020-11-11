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

namespace ePizza_JD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json", "application/json-path+json", "multipart/form-data", "application/form-data")]
    [Produces("application/json")]
    public class PizzasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly IPizzaRepo pizzaRepo;
        private readonly IGenericRepo<Pizza> genericRepo;

        public PizzasController(ApplicationDbContext context, IMapper mapper , IPizzaRepo pizzaRepo, IGenericRepo<Pizza> genericRepo)
        {
            _context = context;
            this.mapper = mapper;
            this.pizzaRepo = pizzaRepo;
            this.genericRepo = genericRepo;
        }

        // GET: api/Pizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaDTO>>> GetPizzas()
        {
            try
            {

                var pizzas = await pizzaRepo.GetPizzasAsync();
                var PizzasDTO = mapper.Map<IEnumerable<PizzaDTO>>(pizzas);

                return Ok(PizzasDTO);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaDTO>> GetPizza(Guid id)
        {
            var pizza = new Pizza();
            try
            {

                //pizza = await _context.Pizzas.FindAsync(id);
                pizza = await pizzaRepo.GetPizzaByIdAsync(id);
                var PizzaDTO = mapper.Map<PizzaDTO>(pizza);
                if (pizza == null)
                {
                    return NotFound();
                }
                return Ok(PizzaDTO);
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
        [HttpPost]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {

            try
            {

            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPizza", new { id = pizza.PizzaId }, pizza);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"expection : {ex}");
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    Statuscode = 400,
                    errorMessage = $"Bewaren van de pizza: '{pizza.Name}' is mislukt"
                }) ;
            }
        }

        // DELETE: api/Pizzas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pizza>> DeletePizza(Guid id)
        {
            //todo ophalen van pizza
            var pizza = new Pizza();
            try
            {
                pizza = await pizzaRepo.GetPizzaByIdAsync(id);
                //pizza = await _context.Pizzas.FindAsync(id);
                if (pizza == null)
                {
                    return NotFound();
                }

                await pizzaRepo.DeletePizza(id);

                return pizza;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"expection : {ex}");
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    Statuscode = 400,
                    errorMessage = $"verwijderen van de pizza: '{pizza.Name}' is mislukt"
                });
            }
        }

        private bool PizzaExists(Guid id)
        {
            return _context.Pizzas.Any(e => e.PizzaId == id);
        }
    }
}
