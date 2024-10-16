using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Stores.Room
{
    public interface IRoomStore // TODO: интерфейсы всегда паблик?
    {
        public IEnumerable<Entities.Room> Get();
        public Task<Entities.Room> GetById(long id);
        public long Create(Entities.Room room); // TODO: Что возвращать на слое данных?
        public void Update(long id, Entities.Room room);
        public void Delete(long id);
    }
}
