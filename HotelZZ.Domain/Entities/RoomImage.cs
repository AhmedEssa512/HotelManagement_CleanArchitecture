using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelZZ.Domain.Entities
{
    public class RoomImage
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;
        public string PublicId { get; set; } = default!;
    }
}