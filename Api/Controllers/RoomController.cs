using Data.Entities;
using Domain.Services.Rooms;
using Microsoft.AspNetCore.Mvc;

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
                IEnumerable<Room> result = await _roomService.GetAsync();
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
                Room result = await _roomService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(Room room)
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


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Room room)
        {
            try
            {
                await _roomService.UpdateAsync(room);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = room.Id }, room); // TODO: В учебниках много раз видел такой пример.
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError); // TODO: Выбивается из стиля. Как правильно?
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _roomService.DeleteAsync(id);  // TODO: Тоже непонятно что возвращать.
            return Ok();
        }
    }
}
