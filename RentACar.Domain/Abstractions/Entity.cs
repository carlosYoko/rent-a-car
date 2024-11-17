namespace RentACar.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            this.Id = id;
        }
        public Guid Id { get; init; }
    }
}
