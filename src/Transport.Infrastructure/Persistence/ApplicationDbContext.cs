using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Domain.Entities;

namespace Transport.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Admin> admins { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Airline> airlines { get; set; }
        public DbSet<Bus> bus { get; set; }
        public DbSet<PlaceAirline> placeAirlines { get; set; }
        public DbSet<PlaceTrain> placeTrains { get; set; }
        public DbSet<TicketAirline> ticketAirlines { get; set; }
        public DbSet<TicketTrain> ticketTrains { get; set; }
        public DbSet<Train> trains { get; set; }

        public DbSet<TicketBus> ticketBuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}