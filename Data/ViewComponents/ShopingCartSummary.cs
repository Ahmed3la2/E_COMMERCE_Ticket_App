using E_ticket.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace E_ticket.Data.ViewComponents
{
    public class ShopingCartSummary:ViewComponent
    {
        private readonly ShopingCart _shopingCart;

        public ShopingCartSummary(ShopingCart shopingCart)
        {
            _shopingCart = shopingCart;
        }
         
        public IViewComponentResult Invoke()
        {
            var items = _shopingCart.GetShopingCartItems();
            return View(items.Count);
        }
    }
}
