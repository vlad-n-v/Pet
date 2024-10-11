using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Stores.Room;
using Data.Stores.Room.DTO;

namespace Domain.Services.Room
{
    public class RoomService : IRoomService
    {
        public IEnumerable<RoomDTO> Get()
        {
            return new RoomStore().Get(); // TODO: нормально ли возвращать вот так возвращать? new? RoomStore()?
        }


        public RoomDTO GetById(long id)
        {
            return new RoomStore().GetById(id); // TODO: Нужно ли создавать переменную Result или нужно сразу возвращать результат
        }


        public long Create(RoomDTO roomDTO)
        {
            long roomId = new RoomStore().Create(roomDTO);// TODO: Выглядит странно new RoomStore().AddRoom(roomDTO);
            if (roomId == 0) { throw new Exception("the 'Room' object could not be created"); } // TODO: какой тип эксепшена?
            return roomId; 
        }

        public void Update(long id, RoomDTO room)
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

            new RoomStore().Update(id, room);
        }

        public void Delete(long id)
        {
            new RoomStore().Delete(id);
        }
    }
}
