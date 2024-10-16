using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Data.Entities;

using Domain.Services.Room;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase, IRoomController
    {
        // TODO: как лучше так? или как ниже?
        // TODO: Может всегда стоит возвращать IActionResult? Какие бестпрасктис?

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    Response.StatusCode = 200;
        //    return new OkObjectResult(new RoomService().Get()) { StatusCode = 200 };
        //}

        private readonly IRoomService _roomService; //TODO: не понял как это работает. где вызывается конструктор класса?

        public RoomController(IRoomService roomService) //TODO: как в конструктор попадает именно эта служба. Я указал только интерфейс. А если будет 2 службы с одинаковым интерфейсом?
        {
            _roomService = roomService; //TODO: как именовать? _roomService или roomService
        }

        [HttpGet]
        [ProducesResponseType<IEnumerable<Room>>(StatusCodes.Status200OK)] // TODO: Нужна ли такая запись? SonarLint предлагает явно описывать возвращаемый тип
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Room> result = _roomService.Get(); // TODO: Создавать дополнительную переменную или сразу передавать в конструктор  return this.Ok(_roomService.Get());
                return this.Ok(result); // TODO: this.Ok(result); или Ok(result);
            }
            catch
            {
                return this.BadRequest();
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            try
            {
                Room result = _roomService.GetById(id);
                return this.Ok(result);
            }
            catch
            {
                return this.BadRequest();
            }
        }


        [HttpPost]
        public IActionResult Create(Room room) // TODO: Почему я ID указываю при вставке? Мне же база его должна вернуть?
        {
            try
            {
                long result = _roomService.Create(room);
                return this.Created("", result); // TODO: Какую url указывать в Created(url, result)
            }
            catch (Exception)
            {
                return this.BadRequest();
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, Room room)  //TODO: везде будет RoomDTO? Это объект слоя базы данных.
        {
            try
            {
                _roomService.Update(id, room);
                return Ok(); // TODO: Что возвращать? типовые коды
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            // TODO: Где выполнять эту проверку
            //RoomDTO roomIten = _rooms.Find(r => r.Id == id);
            //if (roomIten == null)
            //{
            //    return NotFound();
            //}

            _roomService.Delete(id);
            return NoContent(); // TODO: Что возвращать? типовые кодыы
        }
    }
}
