using E_ticket.Data.Base;
using E_ticket.Interface;
using E_ticket.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_ticket.Data
{
    public class MovieRepository: EntityRepository<Movie> ,IMovieService
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllAsyncInclude()
        {
            return await _context.movies.Include(c => c.cinema).ToListAsync();
        }
    }
}
