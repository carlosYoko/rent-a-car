namespace RentACar.Domain.Vehicles
{
    public record Currency(decimal amount, CurrencyType currencyType)
    {
        public static Currency operator +(Currency first, Currency second)
        {
            if (first.currencyType != second.currencyType)
            {
                throw new InvalidOperationException("EL tipo de moneda debe ser el mismo");
            }

            return new Currency(first.amount + second.amount, first.currencyType);
        }

        public static Currency Zero() => new(0, CurrencyType.None);
        public static Currency Zero(CurrencyType currencyType) => new(0, currencyType);
        public bool IsZero() => this == Zero(currencyType);
    }
}
