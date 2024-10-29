using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Data.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterDataDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRoomRepository, RoomRepository>();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<HotelManagerDdContext>(options =>options.UseSqlite(connectionString)); 
            //services.AddDbContext<HotelManagerDdContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
