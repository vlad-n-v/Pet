using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Stores.Room.DTO;

namespace Data.Stores.Room
{
    public interface IRoomStore // TODO: интерфейсы всегда паблик?
    {
        public IEnumerable<RoomDTO> Get();
        public RoomDTO GetById(long id);
        public long Create(RoomDTO room); // TODO: Что возвращать на слое данных?
        public void Update(long id, RoomDTO room);
        public void Delete(long id);
    }
}
