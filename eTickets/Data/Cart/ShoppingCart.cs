using eTickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {        //properties
        public string ShoppingcartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public AppDbContext _context { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        //for SessionID
        public static ShoppingCart GetShoppingCart(IServiceProvider _services)
        {
            ISession session = _services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var _context = _services.GetService<AppDbContext>();
            string _cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", _cartId);
            return new ShoppingCart(_context) { ShoppingcartId = _cartId };
        }

        public List<ShoppingCartItem> GetShoppingCartItems()            
        { 
            if (ShoppingCartItems == null)
            {
                ShoppingCartItems =_context.ShoppingCartItems.
                    Where(n => n.ShoppingCartId == ShoppingcartId).Include(n => n.movie).ToList();
            };
            return ShoppingCartItems;


            //return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingcartId).Include(n => n.movie).ToList());
        }
        //methods
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingcartId).Select(n => n.movie.Price * n.Amount).Sum();
            return total;
        }
        public void AddNewItemToCart(Movie _movie)
        {
            var cartItems = _context.ShoppingCartItems.FirstOrDefault(n => n.movie.Id == _movie.Id && n.ShoppingCartId == ShoppingcartId);

            if (cartItems == null)
            {
                cartItems = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingcartId,
                    movie = _movie,
                    Amount = 1

                };
                _context.ShoppingCartItems.Add(cartItems);

            }
            else
            {
                cartItems.Amount++;

            }
            _context.SaveChanges();


        }
        public void RemoveItemFromCart(Movie _movie)
        {

            var cartItems = _context.ShoppingCartItems.FirstOrDefault(n => n.movie.Id == _movie.Id && n.ShoppingCartId == ShoppingcartId);

            if (cartItems != null)
            {
                if (cartItems.Amount > 1)
                {
                    cartItems.Amount--;
                }else
                _context.ShoppingCartItems.Remove(cartItems);

            }
            _context.SaveChanges();

        }
        public async Task ClearShoppingCartAsync()
        {
            var items =await  _context.ShoppingCartItems.
                Where(n => n.ShoppingCartId == ShoppingcartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
