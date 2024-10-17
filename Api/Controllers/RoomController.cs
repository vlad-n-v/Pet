using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

using Data.Entities;

using Domain.Services.Rooms;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase, IRoomController<Room>
    {
        // TODO: как лучше так? или как ниже?
        // TODO: Может всегда стоит возвращать IActionResult? Какие бестпрасктис?

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    Response.StatusCode = 200;
        //    return new OkObjectResult(new RoomService().Get()) { StatusCode = 200 };
        //}

        private readonly IRoomService<Room> _roomService; //TODO: не понял как это работает. где вызывается конструктор класса?

        public RoomController(IRoomService<Room> roomService) //TODO: как в конструктор попадает именно эта служба. Я указал только интерфейс. А если будет 2 службы с одинаковым интерфейсом?
        {
            _roomService = roomService; //TODO: как именовать? _roomService или roomService
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<Room>>(StatusCodes.Status200OK)] // TODO: Нужна ли такая запись? SonarLint предлагает явно описывать возвращаемый тип
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                IEnumerable<Room> result =  await _roomService.GetAsync(); // TODO: Создавать дополнительную переменную или сразу передавать в конструктор  return this.Ok(_roomService.Get());
                return this.Ok(result); // TODO: this.Ok(result); или Ok(result);
            }
            catch
            {
                return this.BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            try
            {
                Room result = await _roomService.GetByIdAsync(id);
                return this.Ok(result);
            }
            catch
            {
                return this.BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(Room room) // TODO: Почему я ID указываю при вставке? Мне же база его должна вернуть?
        {
            try
            {
                long result = await _roomService.CreateAsync(room);
                return this.Created("", result); // TODO: Какую url указывать в Created(url, result)
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, Room room)  //TODO: везде будет RoomDTO? Это объект слоя базы данных.
        {
            try
            {
                await _roomService.UpdateAsync(id, room);
                return Ok(); // TODO: Что возвращать? типовые коды
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            // TODO: Где выполнять эту проверку
            //RoomDTO roomIten = _rooms.Find(r => r.Id == id);
            //if (roomIten == null)
            //{
            //    return NotFound();
            //}

            await _roomService.DeleteAsync(id);
            return NoContent(); // TODO: Что возвращать? типовые кодыы
        }
    }
}
