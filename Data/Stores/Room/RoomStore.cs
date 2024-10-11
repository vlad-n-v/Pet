using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Stores.Room.DTO;
using Data.Stores.Room.Enum; // TODO: спросить как лучше using или полный путь

namespace Data.Stores.Room
{
    public class RoomStore : IRoomStore
    {
        private List<RoomDTO> _rooms = new List<RoomDTO> // TODO: как называть такие переменные? _rooms
        {
            new RoomDTO{ Id = 1, Number = "101", RoomType = RoomTypes.economy, Price = 2003.40m  },
            new RoomDTO{ Id = 2, Number = "102", RoomType = RoomTypes.economy, Price = 2045.23m  },
            new RoomDTO{ Id = 3, Number = "103", RoomType = RoomTypes.economy, Price = 2544.45m  },
            new RoomDTO{ Id = 4, Number = "104", RoomType = RoomTypes.economy, Price = 2473.22m  },
            new RoomDTO{ Id = 5, Number = "201", RoomType = RoomTypes.standard, Price = 4510.45m  },
            new RoomDTO{ Id = 6, Number = "202", RoomType = RoomTypes.standard, Price = 4863.22m  },
            new RoomDTO{ Id = 7, Number = "203", RoomType = RoomTypes.standard, Price = 4398.25m  },
            new RoomDTO{ Id = 8, Number = "204", RoomType = RoomTypes.standard, Price = 4125.44m  },
            new RoomDTO{ Id = 9, Number = "301", RoomType = RoomTypes.luxury, Price = 6452.34m  },
            new RoomDTO{ Id = 10, Number = "302", RoomType = RoomTypes.luxury, Price = 6714.12m  },
            new RoomDTO{ Id = 11, Number = "303", RoomType = RoomTypes.luxury, Price = 6712.77m  },
        };


        public IEnumerable<RoomDTO> Get() // TODO: Что возвращать IEnumerable или List?
        {
            return _rooms;
        }


        public RoomDTO GetById(long id) // TODO: нейминг id
        {
            return _rooms.FirstOrDefault(r => r.Id == id); // TODO: FirstOrDefault vs First
        }


        public long Create(RoomDTO room)
        {
            _rooms.Add(room);
            long roomId = new Random(10).NextInt64();
            return roomId;
        }


        public void Update(long id, RoomDTO room) // TODO: Что возвращать на этом слое?
        {
            // TODO: проверка id на null
            RoomDTO roomItem = _rooms.Find(r => r.Id == id); // TODO: FirstOrDefault vs First
            roomItem = room;
        }


        public void Delete(long id) // TODO: поговорить про транзакции. Где нужны?
        {
            RoomDTO roomItem = _rooms.Find(r => r.Id == id);
            if (roomItem != null) // TODO: что лучше if (roomIten == null) return; или if (roomItem != null) {действие}
            {
                _rooms.Remove(roomItem);
            }
        }
    }
}