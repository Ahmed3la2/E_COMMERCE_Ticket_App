using E_ticket.Data.Cart;
using E_ticket.Data.ViewModel;
using E_ticket.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_ticket.Controllers
{
    public class OrdersController : Controller
    {
        private IMovieService _movieService { get; set; }
        private ShopingCart _shopingCart { get; set; }
        public IOrderService _orderService { get; set; }


        public OrdersController(IMovieService movieService, ShopingCart shopingCart, IOrderService orderService)
        {
            _movieService = movieService;
            _shopingCart = shopingCart;
            _orderService = orderService;
        }


        public IActionResult GetShopingCartItems()
        {
            var items = _shopingCart.GetShopingCartItems();
            _shopingCart.ShopingcartItems = items;

            var response = new ShopingCartVM
            {
                ShopingCart = _shopingCart,
                ShopingCartTotal = _shopingCart.GetShopingcartTotal(),
            };
            return View(response);
        }

        public async Task<ActionResult> Index()
        {
            string UserId = "a";
            var orderlist = await _orderService.GetOrderByUserIdAsync(UserId);

            return View(orderlist);
        }

        public async Task<RedirectToActionResult> AddToShopingCart(int id)
        {
            var Item = await _movieService.GetMovieByIdAsync(id);
            if (Item != null)
            {
                _shopingCart.AdditemToCart(Item);
            }

            return RedirectToAction(nameof(GetShopingCartItems));
        }

        public async Task<RedirectToActionResult> Removeitemfromcart(int id)
        {
            var Item = await _movieService.GetMovieByIdAsync(id);
            if (Item != null)
            {
                _shopingCart.RemoveShopingCartItem(Item);
            }

            return RedirectToAction(nameof(GetShopingCartItems));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            string UserId = "a";
            string UserEmail = "";
            var Items = _shopingCart.GetShopingCartItems();
            await _orderService.StoreOrder(Items,UserId,UserEmail);
            await _shopingCart.ClearShopingcart();

            return View("OrderCompleted");
        }
    }
}
