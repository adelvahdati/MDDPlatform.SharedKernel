using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.SharedKernel.Entities
{
    public interface IAggregateRoot
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
        void AddEvent(IDomainEvent @event);
        void AddEvents(IReadOnlyList<IDomainEvent> events);
        void ClearEvents();
    }

}