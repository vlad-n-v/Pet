using Data.Stores.Room.DTO;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public interface IRoomController
    {
        public IEnumerable<RoomDTO> Get();
        public RoomDTO GetById(long id);
        public long Create(RoomDTO room); // TODO: Что возвращать на слое API?
        public IActionResult Update(long id, RoomDTO room); // TODO: IActionResult или ActionResult, почему?
        public IActionResult Delete(long id);
    }
}
