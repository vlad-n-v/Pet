using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    public class HotelManagerDdContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }


        public HotelManagerDdContext()
        {
            Database.EnsureCreated();
        }


        public HotelManagerDdContext(DbContextOptions<HotelManagerDdContext> options) : base(options)
        {

        }
    }
}
