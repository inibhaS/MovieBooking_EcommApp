using eTickets.Data.Cart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewComponents
{  
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _shoppingcart;
        public ShoppingCartSummary(ShoppingCart shoppingcart)
        {
            _shoppingcart = shoppingcart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingcart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
