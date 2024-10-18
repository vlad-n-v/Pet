using Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private protected readonly HotelManagerDdContext hotelManagerDbContext;

        public RoomRepository(HotelManagerDdContext context)
        {
            hotelManagerDbContext = context;
        }


        public async Task<List<Room>> GetAsync()
        {
            List<Room> result = await hotelManagerDbContext.Rooms.ToListAsync();
            return result;
        }


        public async Task<Room> GetByIdAsync(long id)
        {
            Room roomItem = await hotelManagerDbContext.Rooms.FirstOrDefaultAsync(r => r.Id == id);
            return roomItem;
        }


        public async Task<long> CreateAsync(Room room)
        {
            EntityEntry<Room> roomItem = await hotelManagerDbContext.Rooms.AddAsync(room);
            await hotelManagerDbContext.SaveChangesAsync();
            return roomItem.Entity.Id;
        }


        public async Task UpdateAsync(long id, Room room)
        {
            Room roomItem = await hotelManagerDbContext.Rooms.FirstOrDefaultAsync(r => r.Id == id);
            if (roomItem != null)
            {
                roomItem = room;
                await hotelManagerDbContext.SaveChangesAsync();
            }
        }


        public async Task DeleteAsync(long id)
        {
            Room roomItem = await hotelManagerDbContext.Rooms.FirstOrDefaultAsync(r => r.Id == id);
            if (roomItem != null)
            {
                hotelManagerDbContext.Rooms.Remove(roomItem);
                await hotelManagerDbContext.SaveChangesAsync();
            }
        }
    }
}
