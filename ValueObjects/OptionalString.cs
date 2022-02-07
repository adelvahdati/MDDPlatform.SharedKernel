using MDDPlatform.SharedKernel.ActionResults;

namespace MDDPlatform.SharedKernel.ValueObjects
{
    public class OptionalString : ValueObject
    {
        
        public virtual string? Value { get; protected set; }
        public bool HasValue {get; protected set;}

        protected OptionalString(string? value){
            if(value == null){
                HasValue =false;
                Value = default(string);
            }
            else{
                HasValue = true;
                Value = value;
            }                            
        }

        public static OptionalString Create(string? value){
            return new OptionalString(value);                
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            var str = string.Empty;
            if(Value == default(string))
                str="[NULL]";
            else
                str= Value;

            yield return HasValue;
            yield return str;
        }
        public static implicit operator string(OptionalString valueObject)
        {                            
            return valueObject.Value;
        }
        public static explicit operator OptionalString(string value){
            return Create(value);
        }                       

    }
}