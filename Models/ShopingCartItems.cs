using System.ComponentModel.DataAnnotations;

namespace E_ticket.Models
{
    public class ShopingCartItems
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public Movie Movie { get; set; }

        public string ShopingCartid { get; set; }
    }
}
