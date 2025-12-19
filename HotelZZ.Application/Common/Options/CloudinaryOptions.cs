using System.ComponentModel.DataAnnotations;

namespace HotelZZ.Application.Common.Options
{
    public class CloudinaryOptions
    {
        [Required]
        public string CloudName { get; set; } = string.Empty;
        [Required]
        public string ApiKey { get; set; } = string.Empty;
        [Required]
        public string ApiSecret { get; set; } = string.Empty;
    }
}