using Data.Entities;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterDataDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddDbContext<HotelManagerDdContext>();
        }
    }
}
