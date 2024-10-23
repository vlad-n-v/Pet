using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.Entities
{
    public class Room
    {
        [Key]
        public long Id { get; set; }
        public string Number { get; set; }
        public RoomTypes RoomType { get; set; }
        public decimal Price { get; set; }
    }
}
