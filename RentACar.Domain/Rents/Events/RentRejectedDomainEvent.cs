using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Rents.Events
{
    public sealed record RentRejectedDomainEvent(Guid RentId) : IDomainEvent;
}
