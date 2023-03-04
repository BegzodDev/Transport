using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class PlaceTrainEntityTypeConfiguration : IEntityTypeConfiguration<PlaceTrain>
    {
        public void Configure(EntityTypeBuilder<PlaceTrain> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.Train)
                .WithMany(x => x.PlaceTrains)
                .HasForeignKey(x => x.TrainId);
        }
    }
}
