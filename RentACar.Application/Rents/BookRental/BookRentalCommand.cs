using RentACar.Application.Abstractions.Messaging;

namespace RentACar.Application.Rents.BookRental
{
    public record BookRentalCommand(
        Guid vehicleId,
        Guid userId,
        DateOnly dateInit,
        DateOnly dateFinish) : ICommand<Guid>;
}
