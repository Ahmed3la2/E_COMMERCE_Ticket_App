using E_ticket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_ticket.Interface
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrderByUserIdAsync(string userId);

        Task StoreOrder(List<ShopingCartItems> cartItems, string userId, string UserEmail);
    }
}
