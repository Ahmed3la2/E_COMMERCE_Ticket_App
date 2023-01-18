using E_ticket.Data.Base;
using E_ticket.Interface;
using E_ticket.Models;

namespace E_ticket.Data
{
    public class CinemaRepository : EntityRepository<Cinema>, ICinemaService
    {
        public CinemaRepository(AppDbContext context) : base(context) { }

    }
}
