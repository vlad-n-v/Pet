using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Enums;

namespace Data.Entities
{
    public class Room // TODO: Спросить про модификаторы доступа по всем слоям
    {
        [Key]
        public long Id { get; set; }
        public string Number { get; set; }
        public RoomTypes RoomType { get; set; } // TODO: Использовать using или писать полный путь? Data.Stores.Room.Enum.RoomTypes EnumType { get; set; }
        public decimal Price { get; set; }
    }
}
