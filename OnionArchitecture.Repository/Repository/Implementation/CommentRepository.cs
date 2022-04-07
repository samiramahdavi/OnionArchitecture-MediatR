using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Repository.Context;
using OnionArchitecture.Repository.Repository.Interface;
using System.Linq;

namespace OnionArchitecture.Repository.Repository.Implementation
{
    public class CommentRepository: GenericRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Any(long id)
        {
            return _dbContext.Comments.Any(c => c.Id == id);
        }
    }
}
