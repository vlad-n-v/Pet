Привет! Будем начинать делать небольшой пет-проект по ТЗ, которое я прикрепил документом. Чтобы получить постепенное погружение мы не будем делать сразу по пунктам, а пойдём постепенно и придем к финальному решению. Если это будет слишком просто/быстро, то увеличим темп и потихоньку будем пропускать промежуточные шаги.

Задачи на первое время:
1. Прочитать небольшую статью, чтобы получить самое базовое понимание о бэкенде. Надо понять что мы вообще будем делать
2. Создать пустой проект ASP .NET Core Web API, там будет один дефолтный контроллер WearherForecast с эндпоинтом GET WeatherForecast 
— это можно увидеть после запуска проекта в Swagger. 

3. Создать свой контроллер и назвать его RoomController. Реализовать методы: GetById(int id), Get(), Update(RoomDto), Delete(int id). 
Внутри контроллера создать коллекцию объектов RoomDto и заполнить любыми объектами на выбор (Описание RoomDto есть в документе)


4. В каждом из методов контроллера реализовать операции с коллекцией элементов. Например, GetById — отдаёт элемент коллекции с соответствующим id, 
Get — возвращает всю коллекцию и тд.

5. Создать репозиторий на GitHub (Прям в UI гитхаба создаешь новый репозиторий и добавляешь туда .readme, которое прикреплю к письму)
6. Клонируешь репозиторий, переносишь туда свой проект
7. Создаёшь новую ветку с названием 'room_controller'
8. Коммитишь свои изменения. Убедись, что туда не попал никакой мусор и находится только код. 
В названии коммита должно быть отражено то, что ты поменял в рамках этого коммита на английском языке. Затем пушишь изменения.

9. Создаёшь Pull Request на мёрж из ветки room_controller в основную и кидаешь мне ссылку

В четверг на созвоне будем смотреть как выглядит код бэкенда в продакшене и разбираться почему именно так


В Data у нас в дальнейшем будет подключение к БД, миграции, описание сущностей и репозитории, сейчас мы там будем оперировать нашим списком.

В Domain бизнес-логика приложения. Там будем делать разные проверки, например: занят ли номер, существует он вообще и тд.

По задачам:
1. Создать два проекта: HotelManager.Data и HotelManager.Domain
2. В проекте HotelManager.Domain создать папку "Services", а в HotelManager.Data "Stores"
3. В папке "Services" создать папку "Room" и в ней два файла: IRoomService (интерфейс) и RoomService (класс с логикой)
4. В "Stores" папку "Room" и в ней два файла: IRoomStore (интерфейс) и RoomStore (тут мы будем манипулировать нашим списком)
5. Настроить DI. С его помощью мы будем в контроллере доставать сервис, а в сервисе стор. Почитать можно тут — https://learn.microsoft.com/ru-ru/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-8.0 и если что пиши
6. Переносим логику из контроллера в стор. У нас там будет список и 5 методов: обновление, получение всех, получение по id, удаление и создание (Обрати внимание, что реализуем обновление, его в контроллере не было)
7. Создаем в сервисе 5 таких же методов. Каждый из них просто вызывает соответствующий метод стора
8. Проверяем решение
