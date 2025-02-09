﻿using Microsoft.EntityFrameworkCore;
using RentACar.Api.Middleware;
using RentACar.Infrastructure;

namespace RentACar.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async void ApplyMigration(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = service.GetRequiredService<ApplicationDbContext>();
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "Error en la migración");

                }
            }
        }

        public static void UseCustomExcepcionnHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
