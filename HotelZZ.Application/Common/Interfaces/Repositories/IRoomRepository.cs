using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities;

namespace HotelZZ.Application.Common.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        public Task CreateAsync(Room room);
        public void DeleteAsync(Room room);
        Task<Room?> GetByIdAsync(int id);
    }
}