using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACar.Application.Abstractions.Clock;
using RentACar.Application.Abstractions.Email;
using RentACar.Infrastructure.Clock;
using RentACar.Infrastructure.Email;

namespace RentACar.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
