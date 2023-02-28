using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities.Traine_Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderTicketTrainEntityTypeConfiguration : IEntityTypeConfiguration<OrderTicketTrain>
    {
        public void Configure(EntityTypeBuilder<OrderTicketTrain> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.OrederForTrain)
                    .WithMany(x => x.OrderTicketTrains)
                    .HasForeignKey(x => x.OrederForTrainId);
        }
    }
}
