using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.Exceptions;

namespace MDDPlatform.SharedKernel.ValueObjects
{
    public class StringValueObject : ValueObject
    {
        public virtual string Value { get; protected set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        protected StringValueObject(string value){
            Value = value;
        }
        public static StringValueObject Create(string value){
            if(value == null)
                throw new NullValueException("Value should not be null");
            return new StringValueObject(value);
        }
        public static IActionResult<StringValueObject> TryCreate(string value){
            if(value == null)
                return TheAction.Failed<StringValueObject>("Value should not be null");
            return TheAction.IsDone<StringValueObject>(new StringValueObject(value));
        }

        public static implicit operator string(StringValueObject valueObject)
        {
            return valueObject.Value;
        }
        public static explicit operator StringValueObject(string value){
            return Create(value);
        }                       
    }
}