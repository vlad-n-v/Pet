using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private protected readonly HotelManagerDdContext _hotelManagerDbContext;

        public RoomRepository(HotelManagerDdContext context)
        {
            _hotelManagerDbContext = context;
        }


        public async Task<List<Room>> GetAsync()
        {
            List<Room> result = await _hotelManagerDbContext.Rooms.ToListAsync();
            return result;
        }


        public async Task<Room> GetByIdAsync(long id)
        {
            Room roomItem = await _hotelManagerDbContext.Rooms.FirstOrDefaultAsync(r => r.Id == id);
            return roomItem;
        }


        public async Task<long> CreateAsync(Room room)
        {
            EntityEntry<Room> roomItem = await _hotelManagerDbContext.Rooms.AddAsync(room);
            await _hotelManagerDbContext.SaveChangesAsync();
            return roomItem.Entity.Id;
        }


        public async Task UpdateAsync(Room room)
        {
            Room roomItem = await _hotelManagerDbContext.Rooms.FirstOrDefaultAsync(r =>r.Id==room.Id);
            if (roomItem != null)
            {
                roomItem = room;
                await _hotelManagerDbContext.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(long id)
        {
            Room roomItem = await _hotelManagerDbContext.Rooms.FirstOrDefaultAsync(r => r.Id == id);
            if (roomItem != null)
            {
                _hotelManagerDbContext.Rooms.Remove(roomItem);
                await _hotelManagerDbContext.SaveChangesAsync();
            }
        }
    }
}
