namespace MDDPlatform.SharedKernel.Entities 
{
    public interface IBaseEntity<TId> {
        TId Id {get;}
    }
}