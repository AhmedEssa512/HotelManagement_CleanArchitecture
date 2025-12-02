using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities;

namespace HotelZZ.Application.Common.Interfaces.Repositories
{
    public interface IRoomTypeRepository
    {
        Task<RoomType?> GetByIdAsync(int id);
        Task CreateAsync(RoomType roomType);
    }
}