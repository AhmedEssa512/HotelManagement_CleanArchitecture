using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Domain.Entities;
using HotelZZ.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HotelZZ.Infrastructure.Repositories
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly ApplicationDbContext _context;
        public AmenityRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Amenity amenity)
        {
            await _context.Amenities.AddAsync(amenity);
        }

        public async Task<Amenity?> GetByIdAsync(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        public async Task<List<Amenity>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Amenities
            .Where(a => ids.Contains(a.Id))
            .ToListAsync();
        }
    }
}