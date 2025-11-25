
namespace HotelZZ.Api.Extensions
{
    public static class ApiDependencies
    {
        public static IServiceCollection AddApiDependencies(
            this IServiceCollection services
        )
        {
            services.AddControllers();
            
            return services;
        }
    }
}