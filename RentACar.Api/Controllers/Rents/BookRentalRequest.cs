namespace RentACar.Api.Controllers.Rents
{
    public sealed record BookRentalRequest(
        Guid VehicleId,
        Guid UserId,
        DateOnly StartDate,
        DateOnly EndDate
        );
}
