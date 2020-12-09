using CartServices.Data;
using CartServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartServices.Repositories
{
    public class CartRepo : GenericRepo<Cart>, ICartRepo
    {
        public CartRepo(CartServicesContext _context) : base(_context)
        {

        }
        //GET
        public async Task<IEnumerable<CartItem>> GetCartItems(Guid cartId)
        {
            Cart cart = await _context.Carts
                .Include(c => c.CartItems)
                .AsNoTracking()
                .Where(c => c.CartId == cartId).FirstOrDefaultAsync();
            //FirstOrDefault niet vergeten (=must voor single Cart return)
            if (cart != null)
            {
                return cart.CartItems;
            }
            else
            {
                return new List<CartItem>();
            }
        }

        public async Task<Cart> CreateCartWithItems(Guid userId, Cart cart)
        {
            cart.CustomerId = userId;
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }


        public async Task<CartItem> InsertCartItem(Guid userId, CartItem cartItem)
        {
            {
                //Doel: historiek van elke transactie bijhouden in tussentabel CartItems
                try
                {
                    if (cartItem.Cart != null)
                    {
                        //1. Cart (FirstOrDefault returnt een null indien onbestaand) 
                        Cart existsCart = _context.Carts.Where(c => c.CartId == cartItem.Cart.CartId).FirstOrDefault();
                        if (existsCart == null)
                        {
                            _context.Entry<Cart>(cartItem.Cart).State = EntityState.Added;
                        }
                        else
                        {
                            _context.Entry<Cart>(cartItem.Cart).State = EntityState.Detached;
                        }

                        //2. CartItem (tussentabel -> die op (unieke) naam werkt)                        
                        var existsItem = _context.CartItems.FirstOrDefault(ci => ci.PizzaName == cartItem.PizzaName && ci.ItemId == cartItem.Cart.CartId);
                        if (existsItem == null)
                        {
                            _context.Entry<CartItem>(cartItem).State = EntityState.Added;
                        }
                        else
                        {
                            //TODO:afspreken met front -> add of update bij wijziging? 

                            cartItem.Quantity += existsItem.Quantity;
                            _context.Entry<CartItem>(cartItem).State = EntityState.Added;
                        }
                    }
                    else
                    {
                        throw new Exception($"Shoppingkar {nameof(cartItem)} kan niet worden opgenomen.");
                    }

                    //Noot: await _context.AddAsync(cartItem); doet een SaveAsync
                    await _context.SaveChangesAsync();
                    return cartItem;
                }
                catch (Exception exc)
                {
                    ////TODO: foutboodschappen afwerken voor InsertCartItem
                    throw new Exception($"Shoppingkar {nameof(cartItem)} kan niet worden opgenomen. {exc.Message }");
                }
            }

        }


        public async Task<IEnumerable<Cart>> GetCartsByUser(Guid userId)
        {
            try
            {
                return await _context.Carts.OrderBy(c => c.DateOfEntry).Include(c => c.CartItems).Where(c => c.CustomerId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
