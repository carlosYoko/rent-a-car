using RentACar.Domain.Vehicles;

namespace RentACar.Infrastructure.Repositories
{
    internal sealed class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
