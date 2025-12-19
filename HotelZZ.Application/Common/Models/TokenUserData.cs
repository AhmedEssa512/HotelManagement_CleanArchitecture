
namespace HotelZZ.Application.Common.Models
{
    public class TokenUserData
    {
        public string UserId { get; init; } = default!;
        public string Email { get; init; } = default!;
        public IReadOnlyCollection<string> Roles { get; init; } = [];

    }
}