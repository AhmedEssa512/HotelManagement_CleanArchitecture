using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelZZ.Domain.Entities
{
    public class HotelFeature
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        
        public ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}