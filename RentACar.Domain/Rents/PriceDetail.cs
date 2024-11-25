using RentACar.Domain.Shared;

namespace RentACar.Domain.Rents
{
    public record PriceDetail(Currency PricePeriod, Currency Maintentance, Currency Accessories, Currency PriceTotal);
}
