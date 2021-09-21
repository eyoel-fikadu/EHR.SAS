using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practitioner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practitioner.Infrastructure.Persistance.Configurations
{
    public class DoctorInsightsConfiguration : IEntityTypeConfiguration<DoctorInsight>
    {
        public void Configure(EntityTypeBuilder<DoctorInsight> builder)
        {
            builder.ToTable("DoctorInsight");

            builder
                .OwnsMany(b => b.Insights);
        }
    }
}
