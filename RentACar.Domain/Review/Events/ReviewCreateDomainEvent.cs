using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Review.Events
{
    public sealed record ReviewCreateDomainEvent(Guid RentId) : IDomainEvent;
}
