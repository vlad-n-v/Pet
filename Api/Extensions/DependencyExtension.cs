using Api.Controllers;

namespace Api.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterApiDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRoomController, RoomController>();
        }
    }
}
