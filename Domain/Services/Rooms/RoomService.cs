using System.Data;

using Data.Entities;
using Data.Repository;

namespace Domain.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository repository)
        {
            this.roomRepository = repository;
        }


        public async Task<List<Room>> GetAsync()
        {
            List<Room> rooms = await roomRepository.GetAsync();
            if (rooms == null || !rooms.Any())
            {
                throw new Exception("'Rooms' not found in the 'roomRepository'");
            }
            return await roomRepository.GetAsync();
        }


        public async Task<Room> GetByIdAsync(long id)
        {
            Room roomItem = await roomRepository.GetByIdAsync(id);
            if (roomItem == null)
            {
                throw new Exception("The 'Room' object with the specified 'ID' not found");
            }
            return await roomRepository.GetByIdAsync(id);
        }


        public async Task<long> CreateAsync(Room room)
        {
            long roomId = await roomRepository.CreateAsync(room);
            if (roomId == 0)
            {
                throw new Exception("The 'Room' object could not be created");
            } 
            return roomId;
        }


        public async Task UpdateAsync(long id, Room room)
        {
            if (room == null) 
            {
                throw new Exception("The 'Room' should not be 'Null'");
            }
            if (id != room.Id)
            {
                throw new ArgumentException("'Id' not match 'Room.Id'");
            }
            await roomRepository.UpdateAsync(id, room);
        }


        public async Task DeleteAsync(long id)
        {
            await roomRepository.DeleteAsync(id);
        }
    }
}
