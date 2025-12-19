
namespace HotelZZ.Application.Common.Options
{
    public class JwtOptions
    {
            public string Key { get; set; } = default!;
            public string Issuer { get; set; } = default!;
            public string Audience { get; set; } = default!;
            public int AccessTokenLifetimeMinutes { get; set; } = 15;
            public int RefreshTokenLifetimeDays { get; set; } = 7;
    }
}