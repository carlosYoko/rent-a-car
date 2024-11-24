using RentACar.Domain.Vehicles;

namespace RentACar.Domain.Rents
{
    public record PriceDetail(Currency PricePeriod, Currency Maintentance, Currency Accessories, Currency PriceTotal);
}
