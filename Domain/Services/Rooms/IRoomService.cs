using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Domain.Services.Rooms // TODO: корректно ли здесь ссылаться на модель из слоя данных или нужно свою создавать?
{
    public interface IRoomService<T>
    {
        public Task<List<T>> GetAsync();
        public Task<T> GetByIdAsync(long id);
        public Task<long> CreateAsync(T room); // TODO: Что возвращать на слое Domain?
        public Task UpdateAsync(long id, T room);
        public Task DeleteAsync(long id);
    }
}
