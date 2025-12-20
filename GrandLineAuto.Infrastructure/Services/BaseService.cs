using GrandLineAuto.Infrastructure.Repositories;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<T>> GetAllEntitiesAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<T> GetEntityById(Guid guidId)
        {
            return await _baseRepository.GetByIdAsync(guidId);
        }
    }
}
