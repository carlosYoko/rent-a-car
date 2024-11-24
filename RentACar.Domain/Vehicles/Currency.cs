namespace RentACar.Domain.Vehicles
{
    public record Currency(decimal Amount, CurrencyType CurrencyType)
    {
        public static Currency operator +(Currency first, Currency second)
        {
            if (first.CurrencyType != second.CurrencyType)
            {
                throw new InvalidOperationException("EL tipo de moneda debe ser el mismo");
            }

            return new Currency(first.Amount + second.Amount, first.CurrencyType);
        }

        public static Currency Zero() => new(0, CurrencyType.None);
        public static Currency Zero(CurrencyType CurrencyType) => new(0, CurrencyType);
        public bool IsZero() => this == Zero(CurrencyType);
    }
}
