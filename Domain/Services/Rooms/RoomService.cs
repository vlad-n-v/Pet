using System.Data;
using Data.Entities;
using Data.Repository;

namespace Domain.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }


        public async Task<List<Room>> GetAsync()
        {
            List<Room> rooms = await _roomRepository.GetAsync();
            if (rooms == null || !rooms.Any())
            {
                throw new Exception("'Rooms' not found in the 'roomRepository'");
            }
            return await _roomRepository.GetAsync();
        }


        public async Task<Room> GetByIdAsync(long id)
        {
            Room roomItem = await _roomRepository.GetByIdAsync(id);
            if (roomItem == null)
            {
                throw new Exception("The 'Room' object with the specified 'ID' not found");
            }
            return await _roomRepository.GetByIdAsync(id);
        }


        public async Task<long> CreateAsync(Room room)
        {
            long roomId = await _roomRepository.CreateAsync(room);
            if (roomId == 0)
            {
                throw new Exception("The 'Room' object could not be created");
            }
            return roomId;
        }


        public async Task UpdateAsync(Room room)
        {
            if (room == null)
            {
                throw new Exception("The 'Room' should not be 'Null'");
            }
            await _roomRepository.UpdateAsync(room);
        }


        public async Task DeleteAsync(long id)
        {
            await _roomRepository.DeleteAsync(id);
        }
    }
}
