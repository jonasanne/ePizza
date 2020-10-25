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
    public class ToppingRepo : IToppingRepo
    {
        private readonly ApplicationDbContext context;

        public ToppingRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Topping> AddTopping(Topping topping)
        {
            try
            {
                topping.ToppingId = Guid.NewGuid();
                var result = context.Toppings.AddAsync(topping);//ChangeTracking
                await context.SaveChangesAsync();
                return topping; //heeft nu een id (autoidentity)
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task DeleteTopping(Guid id)
        {
            try
            {
                Topping Topping = await GetToppingByIdAsync(id);
                if (Topping != null)
                {
                    var result = context.Toppings.Remove(Topping);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
            }
        }

        public Task<Topping> GetToppingByIdAsync(Guid Id)
        {
            try
            {
                return context.Toppings.FirstOrDefaultAsync<Topping>(e => e.ToppingId == Id);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Topping>> GetToppingsAsync()
        {
            try
            {
                return await context.Toppings.OrderBy(n => n.Name).ToListAsync();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }

        public async Task<Topping> UpdateTopping(Topping topping)
        {
            try
            {
                context.Toppings.Update(topping);
                await context.SaveChangesAsync();
                return topping;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                throw null;
            }
        }
    }
}
