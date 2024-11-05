using System.ComponentModel.DataAnnotations;
using Api.Models;
using Domain.Services.Rooms;
using Microsoft.AspNetCore.Mvc;
using static Core.DTOs.Models.RoomDTO;

namespace Api.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase, IRoomController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }


        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<RoomResponseDto>>>> GetAsync()
        {
            try
            {
                IEnumerable<RoomResponseDto> result = await _roomService.GetAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<RoomResponseDto>>> GetByIdAsync(long id)
        {
            try
            {
                RoomResponseDto result = await _roomService.GetByIdAsync(id);
                return Ok(ApiResponse<RoomResponseDto>.SuccessResult(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse<RoomResponseDto>>> CreateAsync(CreateRoomDto room)
        {
            try
            {
                RoomResponseDto romItem = await _roomService.CreateAsync(room);
                return Ok(ApiResponse<RoomResponseDto>.SuccessResult(romItem));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ApiResponse<RoomResponseDto>.ErrorResult(
                    "Validation failed",
                    new List<string>() { ex.Message }));
            }
        }


        [HttpPut]
        public async Task<ActionResult<ApiResponse<RoomResponseDto>>> UpdateAsync(UpdateRoomDto room)
        {
            try
            {
                RoomResponseDto rommItem = await _roomService.UpdateAsync(room);
                return Ok(ApiResponse<RoomResponseDto>.SuccessResult(rommItem));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteAsync(long id)
        {
            await _roomService.DeleteAsync(id);
            return Ok(ApiResponse<bool>.SuccessResult(true));
        }
    }
}
