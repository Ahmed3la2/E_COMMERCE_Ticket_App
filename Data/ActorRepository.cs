using E_ticket.Data.Base;
using E_ticket.Models;

namespace E_ticket.Data
{
    public class ActorRepository : EntityRepository<Actor> , IActorsService
    {
        public ActorRepository(AppDbContext context) : base(context) { }    
    }
}
