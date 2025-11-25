using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelZZ.Domain.Entities.Enums;

namespace HotelZZ.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = default!;
        public int Capacity { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal PricePerNight { get; set; }
        public RoomStatus Status { get; set; } = RoomStatus.Available;
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; } = default!;
        public ICollection<RoomImage> Images { get; set; } = new List<RoomImage>();
        public ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}