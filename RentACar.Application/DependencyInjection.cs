﻿using Microsoft.Extensions.DependencyInjection;
using RentACar.Domain.Rents;

namespace RentACar.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            services.AddTransient<PriceService>();

            return services;
        }
    }
}
