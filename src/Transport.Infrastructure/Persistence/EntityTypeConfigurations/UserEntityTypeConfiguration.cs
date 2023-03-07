using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.TicketAirlines).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.TicketTrains).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.TicketBuses).WithOne(x => x.User).HasForeignKey(x => x.UserId);

        }
    }
}
