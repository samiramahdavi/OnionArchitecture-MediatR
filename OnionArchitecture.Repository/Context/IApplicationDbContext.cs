using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OnionArchitecture.Repository.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Comment> Comments { get; set; }
        Task<Int64> SaveChangesAsync();
    }
}
