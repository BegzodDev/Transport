using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderTicketAirlineEntityTypeConfiguration : IEntityTypeConfiguration<OrderTicketAirline>
    {
        public void Configure(EntityTypeBuilder<OrderTicketAirline> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.OrderForAirline)
                    .WithMany(x => x.OrderTicketAirlines)
                    .HasForeignKey(x => x.OrderForAirlineId);
        }
    }
}
