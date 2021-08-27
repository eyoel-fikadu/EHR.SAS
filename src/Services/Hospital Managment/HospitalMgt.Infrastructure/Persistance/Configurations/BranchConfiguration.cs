using HospitalMgt.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalMgt.Infrastructure.Persistance.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branches>
    {
        public void Configure(EntityTypeBuilder<Branches> builder)
        {
            builder.ToTable("HospitalBranch");

            builder.Property(t => t.BranchName)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .OwnsOne(b => b.Address)
                .ToTable("HospitalBranchAddress");
        }
    }
}
