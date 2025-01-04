using System.Data;

namespace RentACar.Application.Abstractions.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
