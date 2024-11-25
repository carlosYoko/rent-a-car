using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Rents.Events
{
    public sealed record RentCompletedDomainEvent(Guid RentId) : IDomainEvent;
}