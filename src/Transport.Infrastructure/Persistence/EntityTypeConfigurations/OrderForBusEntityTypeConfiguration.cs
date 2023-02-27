using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class OrderForbusEntityTypeConfiguration : IEntityTypeConfiguration<OrderForBus>
    {
        public void Configure(EntityTypeBuilder<OrderForBus> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                    .WithMany(x => x.OrderForBuses)
                    .HasForeignKey(x => x.UserId);

                    
                    
        }
    }
}
