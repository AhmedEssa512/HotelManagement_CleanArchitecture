using HotelZZ.Application.Common.Models;
using HotelZZ.Application.Features.rooms.DTOs;
using HotelZZ.Domain.Entities;
using HotelZZ.Domain.Entities.Enums;

namespace HotelZZ.Application.Common.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        public Task CreateAsync(Room room);
        public void DeleteAsync(Room room);
        Task<Room?> GetByIdAsync(int id);
        Task<PaginatedResult<RoomSummaryDto>> GetRoomsAsync(
            int hotelId,
            int pageNumber,
            int pageSize,
            RoomStatus? status = null
            );

        
    }
}