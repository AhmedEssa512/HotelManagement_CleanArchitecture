using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelZZ.Domain.Entities
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}