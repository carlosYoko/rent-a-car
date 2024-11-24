using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Rents.Events
{
}
public sealed record RentConfirmedDomainEvent(Guid RentId) : IDomainEvent;
