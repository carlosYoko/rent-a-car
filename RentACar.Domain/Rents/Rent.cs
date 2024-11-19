using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Rents
{
    public sealed class Rent : Entity
    {
        public Rent(Guid id) : base(id)
        {
        }

        public RentStatus Status { get; private set; }


    }
}
