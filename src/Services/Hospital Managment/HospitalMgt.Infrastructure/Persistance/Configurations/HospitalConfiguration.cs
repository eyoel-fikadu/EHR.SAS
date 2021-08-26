using HospitalMgt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HospitalMgt.Infrastructure.Persistance.Configurations
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.ToTable("Hospitals");

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .OwnsMany(b => b.Subscriptions);

            builder
                .OwnsMany(b => b.HospitalBranches);

            builder
                .OwnsMany(b => b.HospitalContactInformation);
        }
    }
}
