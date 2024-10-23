using Data.Enums;

namespace Core.DTOs.Models
{
    public class Room
    {

        public class RoomResponseDto
        {
            public long Id { get; set; }
            public string Number { get; set; }
            public RoomTypes RoomType { get; set; }
            public decimal Price { get; set; }
        }


        public class CreateRoomDto // TODO: ID не принимаем назначается базой
        {
            public string Number { get; set; }
            public RoomTypes RoomType { get; set; } // TODO: Ссылка на Data.Enums Нужно ли отдельный енам создавать?
            public decimal Price { get; set; }
        }


        public class UpdateRoomDto
        {
            public long Id { get; set; }
            public string Number { get; set; }
            public RoomTypes RoomType { get; set; }
            public decimal Price { get; set; }
        }

    }
}
