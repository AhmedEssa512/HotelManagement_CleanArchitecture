using HotelZZ.Application.Common.Models;

namespace HotelZZ.Application.Common.Interfaces.Services
{
    public interface ITokenService
    {
        public string GenerateAccessToken(TokenUserData user);
        public string GenerateRefreshToken();
    }
}