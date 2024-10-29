using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using static Core.DTOs.Models.RoomDTO;

namespace Api.Controllers
{
    public interface IRoomController
    {
        public Task<IActionResult> GetAsync();
        public Task<IActionResult> GetByIdAsync(long id);
        public Task<IActionResult> CreateAsync(CreateRoomDto room);
        public Task<IActionResult> UpdateAsync(UpdateRoomDto room);
        public Task<IActionResult> DeleteAsync(long id);
    }
}
