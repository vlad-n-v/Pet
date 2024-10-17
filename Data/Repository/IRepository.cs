using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Entities;

namespace Data.Repository
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAsync();
        public Task<T> GetByIdAsync(long id);
        public Task<long> CreateAsync(T room);
        public Task UpdateAsync(long id, T room);
        public Task DeleteAsync(long id);
    }
}
