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

        public PizzasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Pizzas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaDTO>>> GetPizzas()
        {
            var pizzas=  await _context.Pizzas.ToListAsync();
            var PizzasDTO = mapper.Map<IEnumerable<PizzaDTO>>(pizzas);
            return Ok(PizzasDTO);
        }

        // GET: api/Pizzas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(Guid id)
        {
            var pizza = new Pizza();
            try
            {
                pizza = await _context.Pizzas.FindAsync(id);
                if (pizza == null)
                {
                    return NotFound();
                }
                return pizza;
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
        public async Task<IActionResult> PutPizza(Guid id, Pizza pizza)
        {
            if (id != pizza.PizzaId)
            {
                return BadRequest();
            }

            _context.Entry(pizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
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
                pizza = await _context.Pizzas.FindAsync(id);
                if (pizza == null)
                {
                    return NotFound();
                }

                _context.Pizzas.Remove(pizza);
                await _context.SaveChangesAsync();

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
