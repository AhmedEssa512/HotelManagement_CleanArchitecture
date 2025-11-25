using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HotelZZ.Infrastructure.Persistence.IdentityModel
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}