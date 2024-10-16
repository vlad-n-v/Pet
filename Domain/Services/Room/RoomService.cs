using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Stores.Room;

using Microsoft.VisualBasic;

namespace Domain.Services.Room
{
    public class RoomService : IRoomService
    {
        private readonly IRoomStore _roomStore; //TODO: почему реадонли?

        public RoomService(IRoomStore roomStore)
        {
            _roomStore = roomStore;
        }

        public IEnumerable<Data.Entities.Room> Get()
        {

            return _roomStore.Get(); // TODO: нормально ли возвращать вот так возвращать? new? RoomStore()?
        }


        public Data.Entities.Room GetById(long id)
        {
            return _roomStore.GetById(id); // TODO: Нужно ли создавать переменную Result или нужно сразу возвращать результат
        }


        public long Create(Data.Entities.Room roomDTO)
        {
            long roomId = _roomStore.Create(roomDTO);// TODO: Выглядит странно new RoomStore().AddRoom(roomDTO);
            if (roomId == 0) { throw new Exception("the 'Room' object could not be created"); } // TODO: какой тип эксепшена?
            return roomId;
        }

        public void Update(long id, Data.Entities.Room room)
        {
            if (id != room.Id)
            {
                throw new ArgumentException("'id' not match 'room.id'");
            }

            // TODO: эту ошибку нужно отлавливать на слое Data? Как тогда передавать ошибку? Какие практики?
            //if (roomItem == null) 
            //{
            //    return NotFound();
            //}

            _roomStore.Update(id, room);
        }

        public void Delete(long id)
        {
            _roomStore.Delete(id);
        }
    }
}
