using Api;
using Domain.Services.Rooms;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterDomainDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRoomService, RoomService>();
            services.AddAutoMapper(typeof(RoomsProfile));
        }
    }
}
