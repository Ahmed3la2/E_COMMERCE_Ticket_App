using E_ticket.Data.Cart;
using E_ticket.Migrations;

namespace E_ticket.Data.ViewModel
{
    public class ShopingCartVM
    {
        public ShopingCart ShopingCart   { get; set; }

        public double ShopingCartTotal { get; set; }
    }
}
