using MDDPlatform.Messages.Events;
using MDDPlatform.SharedKernel.Events;

namespace MDDPlatform.SharedKernel.Mappers{
    public class DefaultEventMapper : IEventMapper
    {
        public IEvent Map(IDomainEvent @event)
        {
            return @event;
        }

        public IEnumerable<IEvent> Map(IEnumerable<IDomainEvent> events)
        {
            foreach(var @event in events){
                yield return @event;
            }
        }
    }
}