using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Repository.Repository.Interface
{
    public interface ICommentRepository: IGenericRepository<Comment>
    {
        bool Any(long id);
    }
}
