using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Entities;
using Data.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // TODO: спросить как лучше using или полный путь

namespace Data.Stores.Rooms
{
    [Obsolete]
    public class RoomStore : IRoomStore
    {
        private static HotelManagerDdContext hotelManagerDBContext = new HotelManagerDdContext(); // TODO: Зачем тут static. написал потому что ругался компилятор.

        private DbSet<Room> _rooms = hotelManagerDBContext.Rooms; // TODO: Где инициализировать таблицы. Здесь или в конструкторе?

        //private List<Entities.Room> _rooms = new List<Entities.Room> // TODO: как называть такие переменные? _rooms
        //{
        //    new Entities.Room{ Id = 1, Number = "101", RoomType = RoomTypes.economy, Price = 2003.40m  },
        //    new Entities.Room{ Id = 2, Number = "102", RoomType = RoomTypes.economy, Price = 2045.23m  },
        //    new Entities.Room{ Id = 3, Number = "103", RoomType = RoomTypes.economy, Price = 2544.45m  },
        //    new Entities.Room{ Id = 4, Number = "104", RoomType = RoomTypes.economy, Price = 2473.22m  },
        //    new Entities.Room{ Id = 5, Number = "201", RoomType = RoomTypes.standard, Price = 4510.45m  },
        //    new Entities.Room{ Id = 6, Number = "202", RoomType = RoomTypes.standard, Price = 4863.22m  },
        //    new Entities.Room{ Id = 7, Number = "203", RoomType = RoomTypes.standard, Price = 4398.25m  },
        //    new Entities.Room{ Id = 8, Number = "204", RoomType = RoomTypes.standard, Price = 4125.44m  },
        //    new Entities.Room{ Id = 9, Number = "301", RoomType = RoomTypes.luxury, Price = 6452.34m  },
        //    new Entities.Room{ Id = 10, Number = "302", RoomType = RoomTypes.luxury, Price = 6714.12m  },
        //    new Entities.Room{ Id = 11, Number = "303", RoomType = RoomTypes.luxury, Price = 6712.77m  },
        //};


        public IEnumerable<Room> Get() // TODO: Что возвращать IEnumerable или List?
        {
            return _rooms;
        }


        public async Task<Room> GetById(long id) // TODO: нейминг id или ID
        {
            return await _rooms.FirstOrDefaultAsync(r => r.Id == id); // TODO: FirstOrDefault vs First
        }


        public long Create(Room room)
        {
            _rooms.AddAsync(room);
            hotelManagerDBContext.SaveChangesAsync();
            return room.Id;
        }


        public void Update(long id, Room room) // TODO: Что возвращать на этом слое?
        {
            // TODO: проверка id на null
            //Entities.Room roomItem = _rooms.Find(r => r.Id == id); // TODO: FirstOrDefault vs First
            Room roomItem = _rooms.Find(id); // TODO: FirstOrDefault vs First
            roomItem = room;
        }


        public void Delete(long id) // TODO: поговорить про транзакции. Где нужны?
        {
            Room roomItem = _rooms.Find(id);
            if (roomItem != null) // TODO: что лучше if (roomIten == null) return; или if (roomItem != null) {действие}
            {
                _rooms.Remove(roomItem);
            }
        }
    }
}