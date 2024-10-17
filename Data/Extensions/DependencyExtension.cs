using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Entities;
using Data.Repository;
using Data.Stores.Rooms;

using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
    public static class DependencyExtension //TODO: вообще не понял зачем это нужно и как работает.
    {
        public static void RegisterDataDependencies(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Room>, RepositoryRoom>();
        }
    }
}
