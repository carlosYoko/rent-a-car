using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Rents.Events
{
    public sealed record RentBookedDoaminEvent(Guid RentId) : IDomainEvent;

}
