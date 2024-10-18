### 1. Поднятие MS SQL в Docker:
   - Запустить контейнер с MS SQL Server
   - Проверить статус контейнера

2. Подключение к БД через SSMS:
   - Открыть SQL Server Managment Studio
   - Ввести параметры подключения
   - Создать новую базу данных "HotelManager"

3. Data проект:
   - Установить NuGet пакеты: Microsoft.EntityFrameworkCore и Microsoft.EntityFrameworkCore.SqlServer
   - Создать папку Entities
   - Перенести сущность Room из Core в Data/Entities, добавив атрибут [Key] для Id. Из Core не удаляй, она останется как Dto, а в Data будет сущность 
   - Создать класс HotelManagerDbContext, наследующий DbContext
   - Добавить DbSet<Room> в контекст
   - Создать начальную миграцию с помощью Entity Framework CLI
   - Применить миграцию к базе данных
   - Сделать методы в IRoomStore/RoomStore асинхронными
   - Реализовать RoomRepository, используя HotelManagerDbContext для операций с базой данных

4. Core проект: 
   - Убедиться, что RoomDTO соответствует сущности Room из Data проекта

5. Domain проект:
   - Обновить IRoomService/RoomService, сделав методы асинхронными
   - Обновить логику для работы с асинхронными методами
   - Реализовать конвертацию Entity к Dto ручным способом, то есть берём и перекидываем все поля. Обрати внимание, что Store возвращает сущность, а Service возвращает Dto.

6. Api проект:
   - Установить NuGet пакет Microsoft.EntityFrameworkCore.Tools
   - Добавить строку подключения в appsettings.json
   - Обновить Program.cs:
     - Добавить конфигурацию DbContext
   - Обновить RoomController для работы с асинхронными методами

