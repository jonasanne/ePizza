using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ePizza_JD.Models.Repositories
{
    public interface ICustomerRepo
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid Id);
        Task<Customer> AddCustomer(Customer customer);
        Task DeleteCustomer(Guid id);
        Task<Customer> UpdateCustomer(Customer customer);
    }
}
