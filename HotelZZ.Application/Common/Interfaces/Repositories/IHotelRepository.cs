using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities;

namespace HotelZZ.Application.Common.Interfaces.Repositories
{
    public interface IHotelRepository
    {
        public Task CreateAsync(Hotel hotel);
        public void DeleteAsync(Hotel hotel);
        void UpdateAsync(Hotel hotel);
        
        Task<Hotel?> GetByIdAsync(int id);

        Task<bool> ExistsByNameAsync(string name);
    }
}