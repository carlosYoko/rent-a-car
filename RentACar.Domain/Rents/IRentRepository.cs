using RentACar.Domain.Vehicles;

namespace RentACar.Domain.Rents
{
    public interface IRentRepository
    {
        Task<Rent> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> IsOverLappingAsync(Vehicle vehicle, DateRange dateRange, CancellationToken cancellationToken = default);
        void Add(Rent rent);
    }
}
