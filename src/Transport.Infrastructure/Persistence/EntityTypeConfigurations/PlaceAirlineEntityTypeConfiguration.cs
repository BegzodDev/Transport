using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PlaceAirlineEntityTypeConfiguration : IEntityTypeConfiguration<PlaceAirline>
    {
        public void Configure(EntityTypeBuilder<PlaceAirline> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Airline)
                .WithMany(x => x.PlaceAirlines)
                .HasForeignKey(x => x.AirlineId);
        }
    }
}
