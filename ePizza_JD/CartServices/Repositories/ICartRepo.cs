
using CartServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartServices.Repositories
{
    public interface ICartRepo
    {
        Task<IEnumerable<CartItem>> GetCartItems(Guid cartId);
        Task<IEnumerable<Cart>> GetCartsByUser(Guid userId);
        Task<Cart> CreateCartWithItems(Guid userId, Cart cart);
    }
}
