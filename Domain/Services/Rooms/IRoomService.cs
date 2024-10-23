using Data.Entities;

namespace Domain.Services.Rooms
{
    public interface IRoomService
    {
        public Task<List<Room>> GetAsync();
        public Task<Room> GetByIdAsync(long id);
        public Task<long> CreateAsync(Room room);
        public Task<Room> UpdateAsync(Room room);
        public Task DeleteAsync(long id);
    }
}
