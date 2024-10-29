using Data.Enums;

namespace Core.DTOs.Models
{
    public class RoomDTO
    {
        public class RoomResponseDto
        {
            public long Id { get; set; }
            public string Number { get; set; }
            public RoomTypes RoomType { get; set; }
            public decimal Price { get; set; }
        }


        public class CreateRoomDto
        {
            public string Number { get; set; }
            public RoomTypes RoomType { get; set; }
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
