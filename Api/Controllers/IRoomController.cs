using Data.Entities;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public interface IRoomController
    {
        public Task<IActionResult> GetAsync();
        public Task<IActionResult> GetByIdAsync(long id);
        public Task<IActionResult> CreateAsync(Room room);
        public Task<IActionResult> UpdateAsync(long id, Room room);
        public Task<IActionResult> DeleteAsync(long id);
    }
}
