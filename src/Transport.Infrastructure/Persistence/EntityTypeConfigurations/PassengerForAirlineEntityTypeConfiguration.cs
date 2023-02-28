using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PassengerForAirlineEntityTypeConfiguration : IEntityTypeConfiguration<PassengerForAirline>
    {
        public void Configure(EntityTypeBuilder<PassengerForAirline> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.OrderTicketAirline)
                .WithMany(x => x.PassengerForAirlines)
                .HasForeignKey(x => x.OrderTicketAirlineId);
        }
    }
}
