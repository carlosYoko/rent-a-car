using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Shared;
using RentACar.Domain.Vehicles;

namespace RentACar.Infrastructure.Configurations
{
    internal sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");
            builder.HasKey(vehicle => vehicle.Id);
            builder.OwnsOne(vehicle => vehicle.Adress);
            builder.Property(vehicle => vehicle.Model).HasMaxLength(30).HasConversion(model => model!.Value, value => new Model(value));
            builder.Property(vehicle => vehicle.Vin).HasMaxLength(12).HasConversion(vin => vin!.Value, value => new Vin(value));
            builder.OwnsOne(vehicle => vehicle.Price, pricebuilder =>
            {
                pricebuilder.Property(currency => currency.CurrencyType).HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
            });
            builder.OwnsOne(vehicle => vehicle.Maintenance, priceBuilder =>
            {
                priceBuilder.Property(currency => currency.CurrencyType).HasConversion(currencyType => currencyType.Code, code => CurrencyType.FromCode(code!));
            });
        }
    }
}
