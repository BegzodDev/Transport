using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class BusEntityTypeConfiguration : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.TicketBuses)
                .WithOne(x => x.Bus)
                .HasForeignKey(x => x.BusId);
        }
    }
}
