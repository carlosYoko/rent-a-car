using Microsoft.EntityFrameworkCore;
using RentACar.Domain.Abstractions;

namespace RentACar.Infrastructure.Repositories
{
    internal abstract class Repository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _DbContext.Set<T>().FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public void Add(T entity)
        {
            _DbContext.Add(entity);
        }
    }
}
