using ePizza_JD.WebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ePizza_JD.Models.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly PizzaServiceDbContext context;

        public CustomerRepo(PizzaServiceDbContext context)
        {
            this.context = context;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            try
            {
                customer.CustomerId = Guid.NewGuid();
                var result = context.Customers.AddAsync(customer);//ChangeTracking
                await context.SaveChangesAsync();
                return customer; //heeft nu een id (autoidentity)
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task DeleteCustomer(Guid id)
        {
            try
            {
                Customer Customer = await GetCustomerByIdAsync(id);
                if (Customer != null)
                {
                    var result = context.Customers.Remove(Customer);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
            }
        }

        public Task<Customer> GetCustomerByIdAsync(Guid Id)
        {
            try
            {
                return context.Customers.FirstOrDefaultAsync<Customer>(e => e.CustomerId == Id);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            try
            {
                return await context.Customers.OrderBy(n => n.Name).ToListAsync();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            try
            {
                context.Customers.Update(customer);
                await context.SaveChangesAsync();
                return customer;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                throw null;
            }
        }
    }
}
