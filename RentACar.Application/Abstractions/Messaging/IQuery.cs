using MediatR;
using RentACar.Domain.Abstractions;

namespace RentACar.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
