using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Entities;

using Domain.Services.Rooms;

using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions
{
    public static class DependencyExtension
    {
        public static void RegisterDomainDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRoomService<Room>, RoomService>();
        }
    }
}
