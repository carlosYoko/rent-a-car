using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Rents;
using RentACar.Domain.Vehicles;

namespace RentACar.Infrastructure.Repositories
{
    internal sealed class RentRepository : Repository<Rent>, IRentRepository
    {
        private static readonly RentStatus[] ActiveRentStatuses = { RentStatus.Booked,
                                                                    RentStatus.Confirmed,
                                                                    RentStatus.Completed };

        public RentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsOverLappingAsync(Vehicle vehicle, DateRange dateRange, CancellationToken cancellationToken = default)
        {
            return await _DbContext.Set<Rent>().AnyAsync(rent => rent.VehicleId == vehicle.Id &&
                                                                 rent.Duration.Start <= dateRange.Finish &&
                                                                 rent.Duration.Finish >= dateRange.Start &&
                                                                 ActiveRentStatuses.Contains(rent.Status),
                                                                 cancellationToken);
        }
    }
}
