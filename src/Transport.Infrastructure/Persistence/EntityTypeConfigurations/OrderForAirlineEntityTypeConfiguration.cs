using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderForAirlineEntityTypeConfiguration : IEntityTypeConfiguration<OrderForAirline>
    {
        public void Configure(EntityTypeBuilder<OrderForAirline> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                    .WithMany(x => x.OrderForAirlines)
                    .HasForeignKey(x => x.UserId);



        }
    }
}
