namespace RentACar.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity() { }

        private readonly List<IDomainEvent> _domainEvents = new();

        protected Entity(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; init; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
