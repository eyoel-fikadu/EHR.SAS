using HospitalMgt.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalMgt.Infrastructure.Persistance.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("HospitalBranchAddress");

            builder.Property<int>("Id")  // Id is a shadow property
                .IsRequired();
            builder.HasKey("Id");   // Id is a shadow property
        }
    }
}
