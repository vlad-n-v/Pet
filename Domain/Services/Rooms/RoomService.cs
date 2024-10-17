using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Entities;
using Data.Repository;
using Data.Stores.Rooms;

using Microsoft.VisualBasic;

namespace Domain.Services.Rooms
{
    public class RoomService : IRoomService<Room>
    {
        private readonly IRepository<Room> repository;//TODO: почему реадонли?

        public RoomService(IRepository<Room> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Room>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<Room> GetByIdAsync(long id)
        {
            return await repository.GetByIdAsync(id);// TODO: Нужно ли создавать переменную Result или нужно сразу возвращать результат
        }

        public async Task<long> CreateAsync(Room room)
        {
            long roomId = await repository.CreateAsync(room);
            if (roomId == 0) { throw new Exception("the 'Room' object could not be created"); } // TODO: какой тип эксепшена?
            return roomId;
        }

        public async Task UpdateAsync(long id, Room room)
        {
            // TODO: эту ошибку нужно отлавливать на слое Data? Как тогда передавать ошибку? Какие практики?
            //if (roomItem == null) 
            //{
            //    return NotFound();
            //}
            if (id != room.Id)
            {
                throw new ArgumentException("'id' not match 'room.id'");
            }        
            await repository.UpdateAsync(id, room);
        }

        public async Task DeleteAsync(long id)
        {
            await repository.DeleteAsync(id);
        }             
    }
}
