using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Application.Common.Models;
using HotelZZ.Application.Features.rooms.DTOs;
using HotelZZ.Domain.Entities;
using HotelZZ.Domain.Entities.Enums;
using HotelZZ.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HotelZZ.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Room room)
        {
           await _context.Rooms.AddAsync(room);
        }

        public void DeleteAsync(Room room)
        {
            _context.Rooms.Remove(room);
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return  await _context.Rooms.FindAsync(id);
        }

        public async Task<PaginatedResult<RoomSummaryDto>> GetRoomsAsync(int hotelId, int pageNumber, int pageSize, RoomStatus? status = null)
        {
            var query = _context.Rooms
                .AsNoTracking()
                .Where(r => r.HotelId == hotelId);

            if (status.HasValue)
                query = query.Where(r => r.Status == status.Value);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(r => r.RoomNumber)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new RoomSummaryDto(
                    r.Id,
                    r.RoomNumber,
                    r.Capacity,
                    r.PricePerNight,
                    r.Status
                ))
                .ToListAsync();

            return new PaginatedResult<RoomSummaryDto>(
                items, totalCount, pageNumber, pageSize);
        }
    }
}