using System.Data;

namespace RentACar.Application.Abstractions.Data
{
    internal interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
