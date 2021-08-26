using HospitalMgt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalMgt.Infrastructure.Persistance.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("HospitalSubscription");

            builder.Property(t => t.StartDate)
                .IsRequired();

        }
    }
}
