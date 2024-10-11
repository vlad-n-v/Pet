using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Stores.Room.Enum;

namespace Data.Stores.Room.DTO
{
    public class RoomDTO // TODO: Спросить про модификаторы доступа по всем слоям
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public RoomTypes RoomType { get; set; } // TODO: Использовать using или писать полный путь? Data.Stores.Room.Enum.RoomTypes EnumType { get; set; }
        public decimal Price { get; set; }
    }
}
