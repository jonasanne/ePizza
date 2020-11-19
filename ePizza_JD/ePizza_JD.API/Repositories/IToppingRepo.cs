using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ePizza_JD.Models.Repositories
{
    public interface IToppingRepo
    {
        Task<IEnumerable<Topping>> GetToppingsAsync();

        Task<Topping> GetToppingByIdAsync(Guid Id);
        Task<Topping> AddTopping(Topping topping);
        Task DeleteTopping(Guid id);
        Task<Topping> UpdateTopping(Topping topping);
    }
}
