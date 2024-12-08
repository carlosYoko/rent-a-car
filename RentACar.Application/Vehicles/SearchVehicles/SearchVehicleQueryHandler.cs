using Dapper;
using RentACar.Application.Abstractions.Data;
using RentACar.Application.Abstractions.Messaging;
using RentACar.Domain.Abstractions;
using RentACar.Domain.Rents;

namespace RentACar.Application.Vehicles.SearchVehicles
{
    internal sealed class SearchVehicleQueryHandler : IQueryHandler<SearchVehiclesQuery, IReadOnlyList<VehicleResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        private static readonly int[] ActiveRentStatuses = { (int)RentStatus.Booked, (int)RentStatus.Confirmed, (int)RentStatus.Completed };

        public SearchVehicleQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IReadOnlyList<VehicleResponse>>> Handle(SearchVehiclesQuery request, CancellationToken cancellationToken)
        {
            if (request.dateStart > request.dateEnd)
            {
                return new List<VehicleResponse>();
            }

            const string sql = """
                    SELECT
                        a.id AS Id,
                        a.model AS Model,
                        a.vin AS Vin,
                        a.price_amount AS Price,
                        a.currency AS Currency,
                        a.direction_country AS Country,
                        a.direction_department AS Department,
                        a.direction_province AS Province,
                        a.direction_city AS City,
                        a.direction_street AS Street
                    FROM vehiculos AS a
                    WHERE NOT EXISTS
                    (
                        SELECT 1
                        FROM alquileres AS b
                        WHERE 
                            b.vehicle_id = a.id
                            b.duration_start <= @DateEnd AND
                            b.duration_finish >= @DateStart AND
                            b.status = ANY(@ActiveRentStatuses)
                    )
            """;

            using var connection = _sqlConnectionFactory.CreateConnection();
            var vehicles = await connection.QueryAsync<VehicleResponse, DirectionResponse, VehicleResponse>
                (
                    sql,
                    (vehicle, direction) =>
                    {
                        vehicle.Direction = direction;
                        return vehicle;
                    },
                    new
                    {
                        DateStart = request.dateStart,
                        DateEnd = request.dateEnd,
                        ActiveRentStatuses
                    },
                    splitOn: "Country"
                );

            return vehicles.ToList();
        }
    }
}
