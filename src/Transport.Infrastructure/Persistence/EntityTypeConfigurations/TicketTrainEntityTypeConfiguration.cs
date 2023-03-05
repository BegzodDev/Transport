using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class TicketTrainEntityTypeConfiguration : IEntityTypeConfiguration<TicketTrain>
    {
        public void Configure(EntityTypeBuilder<TicketTrain> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.PlaceTrains)
                .WithOne(x => x.TicketTrain)
                .HasForeignKey<TicketTrain>(x => x.PlaceTrainId);
        }
    }
}
