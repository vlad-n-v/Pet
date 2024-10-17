using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public interface IRoomController<T>
    {
        public Task<IActionResult> GetAsync();
        public Task<IActionResult> GetByIdAsync(long id);
        public  Task<IActionResult> CreateAsync(Room room); // TODO: Что возвращать на слое API?
        public  Task<IActionResult> UpdateAsync(long id, Room room); // TODO: IActionResult или ActionResult, почему?
        public  Task<IActionResult> DeleteAsync(long id);
    }
}
