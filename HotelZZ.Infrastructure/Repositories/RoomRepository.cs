using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Domain.Entities;
using HotelZZ.Infrastructure.Persistence;

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
    }
}