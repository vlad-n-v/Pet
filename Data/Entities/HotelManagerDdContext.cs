using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Entities
{
    public partial class HotelManagerDdContext : DbContext // TODO: Всегда создается partial class?
    {
        public DbSet<Room> Rooms { get; set; } = null!; // TODO: Зачем = null!
        // TODO: когда добавляем таблицы имя миграции как пишем? Add_Rooms ? какие вообще правила есть?
        public HotelManagerDdContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: appsettings.json находится в директории API и в Data.
            // Пришлось, потому что при запуске приложения выполняется API, а при миграции я выполняю Data. Как в этом случае принято поступать
            // При миграции я переключаю запускаемый проект вместо API ставлю Data. Так и надо? 
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        //TODO: Нужно ли использовать Fluent API?
        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
