
namespace HotelZZ.Api.DTOs
{
    public class CreateRoomDto
    {
            public string RoomNumber { get; set; } = default!;
            public int Capacity { get; set; }
            public string Description { get; set; } = default!;
            public decimal PricePerNight { get; set; }

            public int HotelId { get; set; }
            public int RoomTypeId { get; set; }

            public List<int>? AmenityIds { get; set; }

            public List<IFormFile>? Images { get; set; }
    }
}