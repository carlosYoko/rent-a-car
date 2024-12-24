using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Rents;
using RentACar.Domain.Shared;
using RentACar.Domain.Users;
using RentACar.Domain.Vehicles;

namespace RentACar.Infrastructure.Configurations
{
    internal class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("rents");
            builder.HasKey(rent => rent.Id);
            builder.OwnsOne(rent => rent.PriceByPeriod, priceBuilder =>
            {
                priceBuilder.Property(currency => currency.CurrencyType).HasConversion(currency => currency.Code, code => CurrencyType.FromCode(code!));
            });
            builder.OwnsOne(rent => rent.Maintenance, priceBuilder =>
            {
                priceBuilder.Property(currency => currency.CurrencyType).HasConversion(currency => currency.Code, code => CurrencyType.FromCode(code!));
            });
            builder.OwnsOne(rent => rent.Accessories, priceBuilder =>
            {
                priceBuilder.Property(currency => currency.CurrencyType).HasConversion(currency => currency.Code, code => CurrencyType.FromCode(code!));
            });
            builder.OwnsOne(rent => rent.TotalPrice, priceBuilder =>
            {
                priceBuilder.Property(currency => currency.CurrencyType).HasConversion(currency => currency.Code, code => CurrencyType.FromCode(code!));
            });
            builder.OwnsOne(rent => rent.Duration);
            builder.HasOne<Vehicle>().WithMany().HasForeignKey(rent => rent.VehicleId);
            builder.HasOne<User>().WithMany().HasForeignKey(rent => rent.UserId);
        }
    }
}
