namespace MDDPlatform.SharedKernel.ValueObjects 
{
    public abstract class TraceableValueObject : ValueObject
    {
        public TraceId TraceId {get;set;}

        public TraceableValueObject(){
            TraceId = TraceId.Create();
        }        
    }
    public class TraceId : ValueObject
    {
        public Guid Value {get;}

        private TraceId(Guid id){
            Value = id;
        }
        public static TraceId Create(){
            return new TraceId(Guid.NewGuid());
        }

        public static TraceId Load(Guid id)
        {
            return new TraceId(id);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}