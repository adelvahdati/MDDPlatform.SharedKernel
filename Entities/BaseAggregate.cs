using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.SharedKernel.Entities
{
    public abstract class BaseAggregate<TId> : BaseEntity<TId>, IAggregateRoot
    {
        private List<IDomainEvent> _events = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> DomainEvents => _events;

        public void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }
        public void AddEvents(IReadOnlyList<IDomainEvent> events)
        {
            foreach (var @event in events)
            {
                _events.Add(@event);
            }
        }
        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}