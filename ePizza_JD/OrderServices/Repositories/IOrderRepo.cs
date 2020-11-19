using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ePizza_JD.Models.Repositories
{
    public interface IOrderRepo
    {
        Task<IEnumerable<Order>> GetOrdersAsync();

        Task<Order> GetOrderByIdAsync(Guid Id);
        Task<Order> AddOrder(Order order);
        Task DeleteOrder(Guid id);
        Task<Order> UpdateOrder(Order order);

    }
}
