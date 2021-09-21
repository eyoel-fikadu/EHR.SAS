using HospitalMgt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Application.Common.Abstraction
{
    public interface IApplicationDbContext
    {
        DbSet<Hospital> Hospitals { get; set; }
        DbSet<Branches> HospitalBranches{ get; set; }
        DbSet<Subscription> HospitalSubscriptions { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
