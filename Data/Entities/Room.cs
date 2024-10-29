using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Enums;

namespace Data.Entities
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]              
        public long Id { get; set; }
        public string Number { get; set; }
        public RoomTypes RoomType { get; set; }
        public decimal Price { get; set; }
    }
}
