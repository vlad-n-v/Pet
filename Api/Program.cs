
using System.Diagnostics;

using Api.Controllers;
using Api.Extensions;

using Data.Entities;
using Data.Extensions;
using Data.Stores.Rooms;

using Domain.Extensions;
using Domain.Services.Rooms;

using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // TODO: нужно ли стараться не использовать var?
            
            HotelManagerDdContext hotelManagerDBContext = new HotelManagerDdContext();

            bool isConnect = hotelManagerDBContext.Database.CanConnect();



            // Add services to the container.
            var services = builder.Services; // TODO: нужно ли объявлять отдельную переменную services? или лучше  builder.Services.RegisterApiDependencies();
            services.RegisterApiDependencies(); // TODO: Порядок важен?
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
