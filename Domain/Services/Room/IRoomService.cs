using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Stores.Room.DTO;

namespace Domain.Services.Room // TODO: корректно ли здесь ссылаться на модель из слоя данных или нужно свою создавать?
{
   public interface IRoomService
    {
        public IEnumerable<RoomDTO> Get();
        public RoomDTO GetById(long id);
        public long Create(RoomDTO room); // TODO: Что возвращать на слое Domain?
        public void Update(long id, RoomDTO room);
        public void Delete(long id);
    }
}
