using HospitalMgt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
