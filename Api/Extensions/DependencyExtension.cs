using Api.Controllers;

using Data.Entities;

namespace Api.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterApiDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRoomController<Room>, RoomController>();
        }
    }
}
