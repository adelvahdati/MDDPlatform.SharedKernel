using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.Exceptions;

namespace MDDPlatform.SharedKernel.ValueObjects
{
    public class NotEmptyString : ValueObject
    {
        public virtual string Value { get; protected set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        protected NotEmptyString(string value){
            if(value == null)
                throw new NullValueException("Value should not be null");
            if(value.Length==0)
                throw new EmptyStringException("Value should not be empty");

            Value = value;
        }
        public static IActionResult<NotEmptyString> TryCreate(string value){
            if(string.IsNullOrEmpty(value))
                return TheAction.Failed<NotEmptyString>("Value should not be null or empty");
            
            return TheAction.IsDone<NotEmptyString>(new NotEmptyString(value));
        }

        public static implicit operator string(NotEmptyString valueObject)
        {
            return valueObject.Value;
        }
        public static explicit operator NotEmptyString(string value){
            return new NotEmptyString(value);
        }                       
    }
}