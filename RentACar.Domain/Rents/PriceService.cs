using RentACar.Domain.Vehicles;

namespace RentACar.Domain.Rents
{
    public class PriceService
    {
        public PriceDetail CalculatePrice(Vehicle vehicle, DateRange period)
        {
            var currency = vehicle.Price!.CurrencyType;

            var pricePeriod = new Currency(period.QuantityDays * vehicle.Price!.Amount, currency);

            decimal porcentageCange = 0;

            foreach (var accesory in vehicle.Accessories)
            {
                porcentageCange += accesory switch
                {
                    Accessory.AppleCar or Accessory.AndroidCar => 0.05m,
                    Accessory.AirConditioner => 0.01m,
                    Accessory.Maps => 0.01m,
                    _ => 0
                };

            }

            var accesoryCharges = Currency.Zero(currency);

            if (porcentageCange > 0)
            {
                accesoryCharges = new Currency(pricePeriod.Amount * porcentageCange, currency);
            }

            var totalPrice = Currency.Zero();
            totalPrice += pricePeriod;

            if (!vehicle!.Maintenance!.IsZero())
            {
                totalPrice += vehicle.Maintenance;
            }

            totalPrice += accesoryCharges;

            return new PriceDetail(pricePeriod, vehicle.Maintenance, accesoryCharges, totalPrice);
        }
    }
}
