using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Abstractions;

namespace RentACar.Infrastructure
{
    public sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
