using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Infrastructure.Persistence;

namespace HotelZZ.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(
            ApplicationDbContext context,
            IHotelRepository hotels,
            IRoomRepository rooms,
            IRoomTypeRepository roomTypes,
            IAmenityRepository amenities

        )
        {
            _context = context;
            Hotels = hotels;
            Rooms = rooms;
            RoomTypes = roomTypes;
            Amenities = amenities;
        }

        
        public IHotelRepository Hotels { get; }
        public IRoomRepository Rooms { get; }
        public IRoomTypeRepository RoomTypes { get; }
        public IAmenityRepository Amenities { get; }




        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}