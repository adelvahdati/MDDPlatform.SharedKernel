using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.SharedKernel.Entities
{
    public interface IAggregateRoot
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
    }

}