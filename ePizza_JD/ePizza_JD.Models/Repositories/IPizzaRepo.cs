using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ePizza_JD.Models.Repositories
{
    public interface IPizzaRepo
    {

        Task<IEnumerable<Pizza>> GetPizzasAsync();

        Task<Pizza> GetPizzaByIdAsync(Guid Id);
        Task<Pizza> AddPizza(Pizza pizza);
        Task DeletePizza(Guid id);
        Task<Pizza> UpdatePizza(Pizza pizza);




    }
}
