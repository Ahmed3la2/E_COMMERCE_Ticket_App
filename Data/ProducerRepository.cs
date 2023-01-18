using E_ticket.Data.Base;
using E_ticket.Interface;
using E_ticket.Models;

namespace E_ticket.Data
{
    public class ProducerRepository : EntityRepository<Producer>, IProducerService
    {
        public ProducerRepository(AppDbContext context) : base(context) { }

    }
}
