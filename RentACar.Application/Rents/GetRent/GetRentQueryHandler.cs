using Dapper;
using RentACar.Application.Abstractions.Data;
using RentACar.Application.Abstractions.Messaging;
using RentACar.Domain.Abstractions;

namespace RentACar.Application.Rents.GetRent
{
    internal sealed class GetRentQueryHandler : IQueryHandler<GetRentQuery, RentResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GetRentQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<RentResponse>> Handle(GetRentQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();

            var sql = """
               SELECT
                    id AS Id,
                    user_id AS UserId,
                    vehicle_id AS VehicleId,
                    status AS Status,
                    price_rent AS PriceRent,
                    currency_rent AS CurrencyRent,
                    price_maintenance AS PriceMaintenance,
                    currency_maintenance AS CurrencyMaintenance,
                    price_accesories AS PriceAccesories,
                    currency_accesories AS CurrencyAccesories,
                    price_total AS PriceTotal,
                    currency_total AS CurrencyTotal,
                    duration_start AS DurationStart,
                    duration_end AS DurationEnd,
                    date_creation AS DateCreation
               FROM rents WHERE id=@RentId
            """;

            var rent = await connection.QueryFirstOrDefaultAsync<RentResponse>(
                                sql,
                                new
                                {
                                    request.RentId,
                                });
            return rent;
        }
    }
}
