using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Data.Services;
using eTickets.Data.Cart;
using eTickets.Data.ViewModel;

namespace eTickets.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _orderService;
        public OrdersController(IMovieService movieService, ShoppingCart shoppingCart, IOrdersService orderService)
        {
            _movieService = movieService;
            _shoppingCart = shoppingCart;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var _item = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = _item;
            var _response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
                
                
            return View(_response);
        }

        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id )
        {
            var items = await _movieService.GetMovieByIdAsync(id);
            if (items != null)
            {
                _shoppingCart.AddNewItemToCart(items);
               
            
            }
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> RemoveItemsFromShoppingCart(int id)


        {
            var items = await _movieService.GetMovieByIdAsync(id);
            if (items != null)
            {
                _shoppingCart.RemoveItemFromCart(items);


            }
            return RedirectToAction(nameof(Index));

        }

        public async Task< IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";
            await _orderService.StoreOrdersAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
    }
}
