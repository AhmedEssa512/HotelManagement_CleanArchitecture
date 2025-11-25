using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelZZ.Infrastructure.Persistence.IdentityModel
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = default!;
        public string UserId { get; set; } = default!;   
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; } = false;

        public ApplicationUser AppUser { get; set; } = default!;
    }
}