using E_ticket.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_ticket.Data.Cart
{
    public class ShopingCart
    {
        public AppDbContext _context { get; set; }
        public string ShopingCartId { get; set; }
        public List<ShopingCartItems> ShopingcartItems { get; set; }


        public ShopingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShopingCart GetShopingCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetRequiredService<AppDbContext>();

            string cartId = null;

            if (session.GetString("CartId") != null)
            {
                cartId = session.GetString("CartId");
            }
            else
            {
                cartId = Guid.NewGuid().ToString();
            }
            session.SetString("CartId", cartId);
            return new ShopingCart(context) { ShopingCartId = cartId };
        }

        public List<ShopingCartItems> GetShopingCartItems()
        {
            var shopingcart = _context.shopingCartItems.Include(m => m.Movie).Where(s => s.ShopingCartid == ShopingCartId).ToList();
            return shopingcart;
        }

        public double GetShopingcartTotal()
        {
            return _context.shopingCartItems.Where(m => m.ShopingCartid == ShopingCartId).Select(m => m.Movie.Price * m.Amount).ToList().Sum();
        }

        public void AdditemToCart(Movie movie)
        {
            var shopingcarrItem = _context.shopingCartItems
            .FirstOrDefault(sh => sh.Movie.Id == movie.Id && sh.ShopingCartid == ShopingCartId);

            if (shopingcarrItem == null)
            {
                ShopingCartItems item = new ShopingCartItems
                {
                    Movie = movie,
                    Amount = 1,
                    ShopingCartid = ShopingCartId,
                };
                _context.shopingCartItems.Add(item);
                _context.SaveChanges();
            }
            else
            {
                shopingcarrItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveShopingCartItem(Movie movie)
        {
            var shopingcarrItem = _context.shopingCartItems
           .FirstOrDefault(sh => sh.Movie.Id == movie.Id && sh.ShopingCartid == ShopingCartId);

            if (shopingcarrItem != null)
            {
                if (shopingcarrItem.Amount == 1)
                {
                    _context.shopingCartItems.Remove(shopingcarrItem);
                }
                else if (shopingcarrItem.Amount > 1)
                {
                    shopingcarrItem.Amount--;
                }
                _context.SaveChanges();
            }
        }

        public async Task ClearShopingcart()
        {
            var items = await _context.shopingCartItems.Where(s => s.ShopingCartid == ShopingCartId).ToListAsync();
            _context.shopingCartItems.RemoveRange(items);
            _context.SaveChanges();
        }

    }
}
