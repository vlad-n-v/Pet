using static Core.DTOs.Models.RoomDTO;

namespace Domain.Services.Rooms
{
    public interface IRoomService
    {
        public Task<List<RoomResponseDto>> GetAsync();
        public Task<RoomResponseDto> GetByIdAsync(long id);
        public Task<RoomResponseDto> CreateAsync(CreateRoomDto room);
        public Task<RoomResponseDto> UpdateAsync(UpdateRoomDto room);
        public Task DeleteAsync(long id);
    }
}
