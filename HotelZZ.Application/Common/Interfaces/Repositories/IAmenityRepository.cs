using HotelZZ.Domain.Entities;

namespace HotelZZ.Application.Common.Interfaces.Repositories
{
    public interface IAmenityRepository
    {
        Task<Amenity?> GetByIdAsync(int id);
        Task<List<Amenity>> GetByIdsAsync(IEnumerable<int> ids);
        Task CreateAsync(Amenity amenity);
    }
}