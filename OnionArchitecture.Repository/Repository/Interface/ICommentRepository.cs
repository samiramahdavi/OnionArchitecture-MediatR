using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Repository.Repository.Interface
{
    public interface ICommentRepository: IGenericRepository<Comment>
    {
        bool Any(long id);
    }
}
