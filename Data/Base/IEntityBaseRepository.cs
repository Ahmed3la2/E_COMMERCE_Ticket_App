using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_ticket.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<List<T>> GetAsync();

        Task<T> GetByIdAsync(int id);

        void DeleteByIds(int id);

        void Update(T Entity);

        void Add(T Entity);
    }
}
