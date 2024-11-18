namespace RentACar.Domain.Vehicles
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}