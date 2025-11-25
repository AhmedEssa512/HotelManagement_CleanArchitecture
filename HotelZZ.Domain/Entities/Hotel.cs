using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelZZ.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? ImageUrl { get; set; }
        public string? Identifier { get; set; }
        public string Address { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
        public ICollection<HotelFeature> Features { get; set; } = new List<HotelFeature>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    }
}