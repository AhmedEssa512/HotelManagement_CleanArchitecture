
namespace HotelZZ.Application.Common.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IHotelRepository Hotels { get; }
        IRoomRepository Rooms { get; }
        IRoomTypeRepository RoomTypes { get; }
        IAmenityRepository Amenities { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}