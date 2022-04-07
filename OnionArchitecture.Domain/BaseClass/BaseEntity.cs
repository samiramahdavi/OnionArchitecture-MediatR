
namespace OnionArchitecture.Domain.BaseClass
{
    public abstract class BaseEntity<TId> where TId : struct
    {
        public TId Id { get; set; }

        public BaseEntity()
        {

        }

        public BaseEntity(TId id)
        {
            this.Id = id;
        }
    }
}
