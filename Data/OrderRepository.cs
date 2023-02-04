using E_ticket.Interface;
using E_ticket.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_ticket.Data
{
    public class OrderRepository : IOrderService
    {
        public readonly AppDbContext _context;

        public OrderRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string UserRole)
        {
            var Orders = _context.orders.Include(m => m.OrderItems).ThenInclude(m => m.Movie).Include(u => u.User).ToList();

            if (UserRole != "Admin")
            {
                var order = Orders.Where(x => x.UserId == userId);
            }
          

            return Orders;
        }
        public async Task StoreOrder(List<ShopingCartItems> cartItems, string userId, string UserEmail)
        {
            Order order = new Order
            {
                UserId = userId,
                Email = UserEmail
            };
            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in cartItems)
            {
                OrderItem orderItem = new OrderItem
                {
                    Amount = item.Amount,
                    Price = item.Movie.Price,
                    OrderId = order.Id,
                    MovieId = item.Movie.Id
                };
                await _context.orderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }


    }
}
