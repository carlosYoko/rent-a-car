using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Users.Events
{
    public sealed record UserCreateDomainEvent(Guid UserId) : IDomainEvent
    {

    }
}
