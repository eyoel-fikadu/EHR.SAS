using EHR.SAS.Common.Application.Abstraction;
using EHR.SAS.Common.Domain;
using HospitalMgt.Application.Common.Abstraction;
using HospitalMgt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalMgt.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(ICurrentUserService currentUserService, 
            IDateTime dateTime,
            DbContextOptions options) : base(options)
        {
            this._currentUserService = currentUserService;
            this._dateTime = dateTime;
        }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Branches> HospitalBranches { get; set; }
        public DbSet<Subscription> HospitalSubscriptions { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserGuidId;
                        entry.Entity.CreatedDate = _dateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserGuidId;
                        entry.Entity.LastModifiedDate = _dateTime.Now;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);


            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.HasDefaultSchema("hospitalManagment");
            base.OnModelCreating(builder);
        }
    }
}
