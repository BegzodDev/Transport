using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities.Traine_Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PassengerForTrainEntityTypeConfiguration : IEntityTypeConfiguration<PassengerForTrain>
    {
        public void Configure(EntityTypeBuilder<PassengerForTrain> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.OrderTicketTrain)
                .WithMany(x => x.PassengerForTrains)
                .HasForeignKey(x => x.OrderTicketTrainId);
        }
    }
}
