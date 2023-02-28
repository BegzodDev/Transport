using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderForTrainEntityTypeConfiguration : IEntityTypeConfiguration<OrderForTrain>
    {
        public void Configure(EntityTypeBuilder<OrderForTrain> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                    .WithMany(x => x.OrderForTrains)
                    .HasForeignKey(x => x.UserId);



        }
    }
}
