using Api.Models;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using static Core.DTOs.Models.RoomDTO;

namespace Api.Controllers
{
    public interface IRoomController
    {
        public Task<ActionResult<ApiResponse<List<RoomResponseDto>>>> GetAsync();
        public Task<ActionResult<ApiResponse<RoomResponseDto>>> GetByIdAsync(long id);
        public Task<ActionResult<ApiResponse<RoomResponseDto>>> CreateAsync(CreateRoomDto room);
        public Task<ActionResult<ApiResponse<RoomResponseDto>>> UpdateAsync(UpdateRoomDto room);
        public Task<ActionResult<ApiResponse<bool>>> DeleteAsync(long id);
    }
}