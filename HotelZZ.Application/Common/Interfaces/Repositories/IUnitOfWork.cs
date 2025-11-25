using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelZZ.Application.Common.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IHotelRepository Hotels { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}