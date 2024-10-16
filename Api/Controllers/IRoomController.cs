using Data.Stores.Room.DTO;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public interface IRoomController
    {
        public IActionResult Get();
        public IActionResult GetById(long id);
        public IActionResult Create(RoomDTO room); // TODO: Что возвращать на слое API?
        public IActionResult Update(long id, RoomDTO room); // TODO: IActionResult или ActionResult, почему?
        public IActionResult Delete(long id);
    }
}
