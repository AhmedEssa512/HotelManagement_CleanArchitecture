using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities;
using HotelZZ.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using HotelZZ.Application.Common.Interfaces.Repositories;

namespace HotelZZ.Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;
        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Hotel hotel)
        {
           await _context.Hotels.AddAsync(hotel);
        }

        public void UpdateAsync(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
        }

        public void DeleteAsync(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Hotels.AnyAsync(h => h.Name == name);
        }

        public async Task<Hotel?> GetByIdAsync(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }
    }
}