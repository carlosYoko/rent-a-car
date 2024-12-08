namespace RentACar.Application.Rents.GetRent
{
    public sealed class RentResponse
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public Guid VehicleId { get; init; }
        public int Status { get; init; }
        public decimal PriceRent { get; init; }
        public string? CurrencyRent { get; init; }
        public decimal PriceMaintenance { get; init; }
        public string? CurrencyMaintenance { get; init; }
        public decimal PriceAccesories { get; init; }
        public string? CurrencyAccesories { get; init; }
        public decimal PriceTotal { get; init; }
        public string? CurrencyTotal { get; init; }
        public DateOnly DurationStart { get; init; }
        public DateOnly DurationEnd { get; init; }
        public DateTime DateCreation { get; init; }
    }
}
