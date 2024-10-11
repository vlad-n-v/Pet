using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

using Data.Stores.Room.DTO;

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


        [HttpGet]
        public IEnumerable<RoomDTO> Get()
        {
            Response.StatusCode = 200;
            return new RoomService().Get();
        }



        [HttpGet("{id}")]
        public RoomDTO GetById(long id)
        {
            Response.StatusCode = 200; // TODO: Если не найден что возвращать? и где обрабатывать? в Data?
            return new RoomService().GetById(id);
        }


        [HttpPost]
        public long Create(RoomDTO room)
        {
            // TODO: какой обработчик ошибок здесь писать?

            try
            {
                Response.StatusCode = 200; // Тут тоже обработку ошибок надо сделать?
                return new RoomService().Create(room); // TODO: нормальна ли такая запись?  new RoomService().AddRoom(room);
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return 0; // TODO: Что возвращать long или IActionResult
            }
        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, RoomDTO room)
        {
            try
            {
                new RoomService().Update(id, room);
                return Ok();
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

            new RoomService().Delete(id);
            return NoContent();
        }
    }
}
