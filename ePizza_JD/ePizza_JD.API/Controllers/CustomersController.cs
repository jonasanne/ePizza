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
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;
        private readonly IGenericRepo<Customer> genericRepo;

        public CustomersController(ApplicationDbContext context, IMapper mapper, IGenericRepo<Customer> genericRepo)
        {
            _context = context;
            this.mapper = mapper;
            this.genericRepo = genericRepo;
        }

        // GET: api/Customers
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            try
            {

                var customers = await genericRepo.GetAllAsync();
                var customerDTOs = mapper.Map<IEnumerable<CustomerDTO>>(customers);

                return Ok(customerDTOs);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Customers/5
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RestaurantDTO), (int)HttpStatusCode.OK)]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(Guid id)
        {
            var customers = await genericRepo.GetByExpressionAsync(m => m.CustomerId == id);

            // Vergeet de count niet! Customer is een collectie en nooit null
            if (customers == null || customers.Count() == 0)
            {
                return NotFound(new { message = "Customer niet gevonden." });
                //return NotFound();
            }
            Customer customer = customers.FirstOrDefault<Customer>();
            return Ok(mapper.Map<CustomerDTO>(customer));
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, CustomerDTO customerDTO)
        {
            if (id != customerDTO.Id || customerDTO == null)
            {
                return BadRequest();
            }

            //2. mapping
            var customer = mapper.Map<Customer>(customerDTO);
            if (customer == null)
            {
                return BadRequest(new { Messsage = "Onvoldoende data bij de Customer" });
            }

            //3. Validatie
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Messsage = $"Geen geldige input. {ModelState}" });

            }

            try
            {
                Customer customerSearch = (await genericRepo.GetByExpressionAsync(c => c.CustomerId == customerDTO.Id)).FirstOrDefault();
                await genericRepo.Update(mapper.Map<Customer>(customerDTO), id);
                //return Ok(new { Message = $"Topping with name: {topping.Name} has been Correctly updated" });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!genericRepo.Exists(customer, id).Result)

                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction("HandleErrorCode", "Error", new
                    {
                        statusCode = 400,
                        errorMessage = $"De Customer met naam : '{customer.Name}' werd niet aangepast."
                    });
                }
            }

            return NoContent();

        }

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> PostCustomer(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest(new { Message = "Geen Customer input" });
            };

            var customer = mapper.Map<Customer>(customerDTO);
            if (customer == null)
            {
                return BadRequest(new { Message = "Onvoldoende data bij de customer" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await genericRepo.Create(customer);
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, mapper.Map<CustomerDTO>(customer));
            }
            catch (Exception exc)
            {

                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Het bewaren van customer met naam: '{customer.Name}' is mislukt."
                });
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(Guid id)
        {
            var customers = await genericRepo.GetByExpressionAsync(c => c.CustomerId == id);
            if (customers == null || customers.Count() == 0)
            {
                return NotFound(new { message = "Restaurant niet gevonden." });
            }

            Customer customer = customers.FirstOrDefault<Customer>();
            try
            {

                await genericRepo.Delete(customer);

            }
            catch
            {
                //Customised gebruikers error
                return RedirectToAction("HandleErrorCode", "Error", new
                {
                    statusCode = 400,
                    errorMessage = $"Het verwijderen van de customer met naam: '{customer.Name}' is mislukt."
                });

            }

            return Ok(mapper.Map<CustomerDTO>(customer));
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
