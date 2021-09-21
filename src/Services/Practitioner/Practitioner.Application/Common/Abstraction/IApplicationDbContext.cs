using Microsoft.EntityFrameworkCore;
using Practitioner.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Practitioner.Application.Common.Abstraction
{
    public interface IApplicationDbContext
    {
        DbSet<DoctorInsight> DoctorInsight { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
