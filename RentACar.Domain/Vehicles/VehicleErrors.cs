using RentACar.Domain.Abstractions;

namespace RentACar.Domain.Vehicles
{
    public static class VehicleErrors
    {
        public static Error NotFound = new Error("Error.Found", "El ID del vehiculo no existe");
    }
}
