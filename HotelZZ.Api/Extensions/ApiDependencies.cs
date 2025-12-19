using System.Text;
using System.Text.Json.Serialization;
using HotelZZ.Application.Common.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace HotelZZ.Api.Extensions
{
    public static class ApiDependencies
    {
        public static IServiceCollection AddApiDependencies(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.AddControllers()
            .AddJsonOptions(options =>
                {
                    // Serialize enums as strings instead of integers
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });;

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            // jwt 
            var jwtSettings = config
                        .GetSection("Jwt")
                        .Get<JwtOptions>()!;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Key))
                    };
                });

            services.AddAuthorization();  

            
            
            return services;
        }
    }
}