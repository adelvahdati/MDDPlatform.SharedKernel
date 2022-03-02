using MDDPlatform.Messages.Events;
using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.SharedKernel.Mappers{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> Map(IEnumerable<IDomainEvent> @events);
    }
}