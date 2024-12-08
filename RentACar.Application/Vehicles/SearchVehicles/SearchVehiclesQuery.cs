using RentACar.Application.Abstractions.Messaging;

namespace RentACar.Application.Vehicles.SearchVehicles
{
    public record SearchVehiclesQuery(DateOnly dateStart, DateOnly dateEnd) : IQuery<IReadOnlyList<VehicleResponse>>;
}
