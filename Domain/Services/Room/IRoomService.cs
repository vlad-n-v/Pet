using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Domain.Services.Room // TODO: корректно ли здесь ссылаться на модель из слоя данных или нужно свою создавать?
{
    public interface IRoomService
    {
        public IEnumerable<Data.Entities.Room> Get();
        public Data.Entities.Room GetById(long id);
        public long Create(Data.Entities.Room room); // TODO: Что возвращать на слое Domain?
        public void Update(long id, Data.Entities.Room room);
        public void Delete(long id);
    }
}
