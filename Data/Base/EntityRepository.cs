using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_ticket.Data.Base
{
    public class EntityRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T actor)
        {
            _context.Set<T>().Add(actor);
            _context.SaveChanges();
        }


        public async Task<List<T>> GetAsync()
        {
            var Actors = await _context.Set<T>().ToListAsync();

            return Actors;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var Actor = await _context.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            return Actor;
        }


        public void DeleteByIds(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(i => i.Id == id);
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
