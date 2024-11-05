using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Entities
{
    public class HotelManagerDdContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public HotelManagerDdContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var settingPath = Path.GetFullPath(Path.Combine(@"../Data/appsettings.json"));
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(settingPath)
                 .Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);

        }
    }
}
