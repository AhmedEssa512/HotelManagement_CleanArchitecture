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
            IHotelRepository hotels
        )
        {
            _context = context;
            Hotels = hotels;
        }

        
        public IHotelRepository Hotels { get; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}