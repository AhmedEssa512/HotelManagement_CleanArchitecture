using FluentValidation;
using HotelZZ.Application.Common.Behaviors;
using HotelZZ.Application.Extensions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HotelZZ.Application.Extensions
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddApplicationDependencies(
            this IServiceCollection services
        )
        {

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ApplicationMarker).Assembly));
                
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

                // Register FluentValidation validators
                services.AddValidatorsFromAssembly(typeof(ApplicationMarker).Assembly);


            return services;
        }
    }
}