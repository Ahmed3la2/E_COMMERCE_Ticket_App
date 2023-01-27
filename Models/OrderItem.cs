using System.ComponentModel.DataAnnotations;

namespace E_ticket.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public int MovieId { get; internal set; }
        public Movie Movie { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; internal set; }
    }

}