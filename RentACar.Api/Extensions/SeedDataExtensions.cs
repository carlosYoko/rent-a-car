using Bogus;
using Dapper;
using RentACar.Application.Abstractions.Data;
using RentACar.Domain.Vehicles;

namespace RentACar.Api.Extensions
{
    public static class SeedDataExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
            using var connection = sqlConnectionFactory.CreateConnection();

            var faker = new Faker();

            List<object> vehicles = new();

            for (var i = 0; i < 10; i++)
            {
                vehicles.Add(new
                {
                    Id = Guid.NewGuid(),
                    Vin = faker.Vehicle.Vin(),
                    Model = faker.Vehicle.Model(),
                    Country = faker.Address.Country(),
                    Department = faker.Address.State(),
                    Province = faker.Address.Country(),
                    City = faker.Address.City(),
                    Street = faker.Address.StreetAddress(),
                    AmountPrice = faker.Random.Decimal(1000, 20000),
                    PriceTypeCurrency = "EU",
                    PriceMaintenance = faker.Random.Decimal(100, 200),
                    PriceMaintentanceTypeCurrency = "EU",
                    Accesories = new List<int> { (int)Accessory.Wifi, (int)Accessory.AppleCar },
                    LastDate = DateTime.MinValue
                });
            }

            const string sql = """
                    INSERT INTO public."Vehicles"
                    (id, vin, model, price_amount, price_currency_type, maintenance_amount, maintenance_currency_type, accessories, date_last_rent)
                    VALUES (@Id, @Vin, @Model, @AmountPrice, @PriceTypeCurrency, @PriceMaintenance, @PriceMaintentanceTypeCurrency, @Accesories, @LastDate)
                """;

            connection.Execute(sql, vehicles);
        }
    }
}
