
using Api.Controllers;
using Api.Extensions;

using Data.Stores.Extensions;
using Data.Stores.Room;

using Domain.Extensions;
using Domain.Services.Room;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var services = builder.Services; // TODO: нужно ли объ€вл€ть отдельную переменную services? или лучше  builder.Services.RegisterApiDependencies();
            services.RegisterApiDependencies();
            services.RegisterDomainDependencies();
            services.RegisterDataDependencies();           

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
