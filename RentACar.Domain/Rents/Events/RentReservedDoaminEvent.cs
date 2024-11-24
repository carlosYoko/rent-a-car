using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Rents.Events
{
    public sealed record RentReservedDoaminEvent(Guid RentId) : IDomainEvent;

}
