using Data.Entities;
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
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                IEnumerable<RoomResponseDto> result = await _roomService.GetAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            try
            {
                RoomResponseDto result = await _roomService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateRoomDto room)
        {
            try
            {
                long romId = await _roomService.CreateAsync(room);
                return Created("", romId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateRoomDto room)
        {
            try
            {
                await _roomService.UpdateAsync(room);
                return await GetByIdAsync(room.Id);
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
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _roomService.DeleteAsync(id);
            return Ok();
        }
    }
}
