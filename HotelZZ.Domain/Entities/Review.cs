using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelZZ.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public UserProfile User { get; set; } = default!;
        public int Rating { get; set; } 
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}