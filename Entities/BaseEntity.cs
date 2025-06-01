namespace MDDPlatform.SharedKernel.Entities
{
    public abstract class BaseEntity<TId> : IBaseEntity<TId>
    {
        protected virtual object ActualInstance => this;
        public virtual TId Id { get; protected set; }
        public bool IsTransient()
        {
            if(Id == null)
                return (default(TId) == null);
            else
                return Id.Equals(default(TId));            
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is BaseEntity<TId>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (BaseEntity<TId>)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return Equals(item.Id,this.Id);                                   
        }

        public override int GetHashCode()
        {
            return (ActualInstance.GetType().ToString()+Id).GetHashCode();
        }

        public static bool operator ==(BaseEntity<TId> left,BaseEntity<TId> right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }
        public static bool operator !=(BaseEntity<TId> left, BaseEntity<TId> right)
        {
            return !(left == right);
        }

    }
}