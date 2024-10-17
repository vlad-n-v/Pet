using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Stores.Rooms
{
    [Obsolete]// убираем всё. оставляем репозиторий
    public interface IRoomStore // TODO: интерфейсы всегда паблик?
    {
        public IEnumerable<Room> Get();
        public Task<Room> GetById(long id);
        public long Create(Room room); // TODO: Что возвращать на слое данных?
        public void Update(long id, Room room);
        public void Delete(long id);
    }
}
