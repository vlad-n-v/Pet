using Data.Entities;

namespace Data.Repository
{
    public interface IRoomRepository
    {
        public Task<List<Room>> GetAsync();
        public Task<Room> GetByIdAsync(long id);
        public Task<Room> CreateAsync(Room room);
        public Task<Room> UpdateAsync(Room room);
        public Task DeleteAsync(long id);
    }
}