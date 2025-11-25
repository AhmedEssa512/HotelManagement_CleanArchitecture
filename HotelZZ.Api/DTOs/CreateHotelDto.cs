using System.ComponentModel.DataAnnotations;

namespace HotelZZ.Api.DTOs
{
    public class CreateHotelDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        [Required]
        public IFormFile? Image { get; set; } 
    }
}