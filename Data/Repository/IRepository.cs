using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Entities;

namespace Data.Repository
{
    public interface IRepository
    {
        public Task<List<Room>> GetAsync();
        public Task<Room> GetByIdAsync(long id);
        public Task<long> CreateAsync(Room room);
        public Task UpdateAsync(long id, Room room);
        public Task DeleteAsync(long id);
    }
}
