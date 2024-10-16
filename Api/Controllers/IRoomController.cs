using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public interface IRoomController
    {
        public IActionResult Get();
        public IActionResult GetById(long id);
        public IActionResult Create(Room room); // TODO: Что возвращать на слое API?
        public IActionResult Update(long id, Room room); // TODO: IActionResult или ActionResult, почему?
        public IActionResult Delete(long id);
    }
}
