using RentACar.Application.Abstractions.Messaging;

namespace RentACar.Application.Rents.GetRent
{
    public sealed record GetRentQuery(Guid RentId) : IQuery<RentResponse>;
}
