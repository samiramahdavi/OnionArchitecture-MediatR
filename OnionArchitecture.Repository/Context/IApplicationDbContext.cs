using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.Repository.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Comment> Comments { get; set; }
        Task<Int64> SaveChangesAsync();
    }
}
