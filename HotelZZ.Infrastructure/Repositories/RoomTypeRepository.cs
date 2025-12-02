using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Domain.Entities;
using HotelZZ.Infrastructure.Persistence;

namespace HotelZZ.Infrastructure.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {

        private readonly ApplicationDbContext _context;

        public RoomTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RoomType?> GetByIdAsync(int id)
        {
            return await _context.RoomTypes.FindAsync(id);
        }

        public async Task CreateAsync(RoomType roomType)
        {
            await _context.RoomTypes.AddAsync(roomType);
        }
    }
}