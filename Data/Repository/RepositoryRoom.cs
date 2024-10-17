using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Data.Repository
{
    public class RepositoryRoom : IRepository<Room>
    {
        protected readonly HotelManagerDdContext db;

        public RepositoryRoom()
        {
            this.db = new HotelManagerDdContext();
        }

        async public Task<List<Room>> GetAsync()
        {
            var result = await db.Rooms.ToListAsync();
            return result;
        }

        async public Task<Room> GetByIdAsync(long id)
        {
            return await db.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        }

        async public Task<long> CreateAsync(Room room)
        {
            await db.Rooms.AddAsync(room);
            await db.SaveChangesAsync();
            return room.Id;
        }

        async public Task UpdateAsync(long id, Room room)
        {
            Room roomItem = await db.Rooms.FindAsync(id); // TODO: FirstOrDefault vs Find
            if (roomItem != null)
            {
                roomItem = room;
                await db.SaveChangesAsync();
            }
        }

        async public Task DeleteAsync(long id)
        {
            Room roomItem = await db.Rooms.FindAsync(id);
            if (roomItem != null) // TODO: что лучше if (roomIten == null) return; или if (roomItem != null) {действие}
            {
                db.Rooms.Remove(roomItem);
                await db.SaveChangesAsync();
            }
        }
    }
}
