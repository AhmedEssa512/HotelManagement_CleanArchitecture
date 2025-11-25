using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelZZ.Domain.Entities
{
    public class UserProfile
    {
        public string Id { get; set; } = default!;  // as same as User provider Id
        public string FullName { get; set; } = default!;
	    public string? PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}