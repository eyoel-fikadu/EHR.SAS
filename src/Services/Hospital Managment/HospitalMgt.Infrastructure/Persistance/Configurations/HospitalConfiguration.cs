using HospitalMgt.Domain.Entities;
using HospitalMgt.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

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
                .Property(x => x.Type)
                .HasConversion<string>();

            builder
                .Property(x => x.Classification)
                .HasConversion<string>();
           
            
            builder
                .HasMany(b => b.Subscriptions);

            builder
                .HasMany(b => b.HospitalBranches);

            builder
                .OwnsMany(b => b.HospitalContactInformation);
        }
    }
}
