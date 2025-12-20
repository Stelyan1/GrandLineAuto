using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> All();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid guidId);
        Task AddAsync(T Entity);
        void UpdateAsync(T Entity);
        void DeleteAsync(T Entity);
        Task SaveChangesAsync();
    }
}
