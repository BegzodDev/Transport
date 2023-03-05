using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class TicketAirlineEntityTypeConfiguration : IEntityTypeConfiguration<TicketAirline>
    {
        public void Configure(EntityTypeBuilder<TicketAirline> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.PlaceAirline)
                .WithOne(x => x.TicketAirline)
                .HasForeignKey<TicketAirline>(x => x.PlaceAirlineId);
        }
    }
}
