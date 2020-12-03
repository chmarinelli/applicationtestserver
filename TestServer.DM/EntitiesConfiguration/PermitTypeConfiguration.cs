using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestServer.DM.Entities;

namespace TestServer.DM.EntitiesConfiguration
{
    public class PermitTypeConfiguration : IEntityTypeConfiguration<PermitType>
    {
        public void Configure(EntityTypeBuilder<PermitType> builder)
        {
            builder.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsRequired();
        }
    }
}
