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
    public class PizzaRepo : IPizzaRepo
    {
        private readonly ApplicationDbContext context;

        public PizzaRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Pizza> AddPizza(Pizza pizza)
        {
            try
            {
                pizza.PizzaId = Guid.NewGuid();
                var result = context.Pizzas.AddAsync(pizza);//ChangeTracking
                await context.SaveChangesAsync();
                return pizza; //heeft nu een id (autoidentity)
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task DeletePizza(Guid id)
        {
            try
            {
                Pizza pizza = await GetPizzaByIdAsync(id);
                if(pizza!=null)
                {
                    var result = context.Pizzas.Remove(pizza);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
            }
        }
        public async Task<IEnumerable<Pizza>> GetPizzasAsync()
        {
            try
            {
                //TODO verder uitwerken
                return await context.Pizzas.OrderBy(n => n.Name).Include(p=> p.PizzaToppings).ThenInclude(t => t.Topping).ToListAsync();
            
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.InnerException.Message);
                throw null;
            }
        }
        public Task<Pizza> GetPizzaByIdAsync(Guid Id)
        {
            try
            {
                return context.Pizzas.Include(p => p.PizzaToppings).FirstOrDefaultAsync(e => e.PizzaId == Id);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                return null;
            }
        }

        public async Task<Pizza> UpdatePizza(Pizza pizza)
        {
            try
            {
                context.Pizzas.Update(pizza);
                await context.SaveChangesAsync();
                return pizza;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.InnerException.Message);
                throw null;
            }
        }
    }
}


//restaurant project, order project,  class library verliezen en models inside api's
//program.cs aanpassen 