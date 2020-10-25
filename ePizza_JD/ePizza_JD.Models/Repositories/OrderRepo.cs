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
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext context;

        public OrderRepo(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<Order> AddOrder(Order order)
        {
            try
            {
                order.OrderId = Guid.NewGuid();
                var result = context.Orders.AddAsync(order);//ChangeTracking
                await context.SaveChangesAsync();
                return order; //heeft nu een id (autoidentity)
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task DeleteOrder(Guid id)
        {
            try
            {
                Order order = await GetOrderByIdAsync(id);
                if (order != null)
                {
                    var result = context.Orders.Remove(order);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
            }
        }

        public Task<Order> GetOrderByIdAsync(Guid Id)
        {
            try
            {
                return context.Orders.FirstOrDefaultAsync<Order>(e => e.OrderId == Id);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            try
            {
                return await context.Orders.OrderBy(n => n.Date).ToListAsync();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            try
            {
                context.Orders.Update(order);
                await context.SaveChangesAsync();
                return order;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                throw null;
            }
        }
    }
}
