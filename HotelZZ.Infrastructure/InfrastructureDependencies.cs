using CloudinaryDotNet;
using HotelZZ.Application.Common.Interfaces.Repositories;
using HotelZZ.Application.Common.Interfaces.Services;
using HotelZZ.Infrastructure.Persistence;
using HotelZZ.Infrastructure.Persistence.IdentityModel;
using HotelZZ.Infrastructure.Repositories;
using HotelZZ.Infrastructure.Services;
using HotelZZ.Infrastructure.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HotelZZ.Infrastructure
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            // Bind & validate Cloudinary settings
            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));

            services.AddOptions<CloudinarySettings>()
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddSingleton(provider =>
            {
                var settings = provider.GetRequiredService<IOptions<CloudinarySettings>>().Value;

                var account = new Account(
                    settings.CloudName,
                    settings.ApiKey,
                    settings.ApiSecret);

                return new Cloudinary(account)
                {
                    Api = { Secure = true }
                };
            });
        
            services.AddScoped<IImageService, CloudinaryImageService>();

            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}