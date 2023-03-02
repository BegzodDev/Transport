using Microsoft.EntityFrameworkCore;
using Transport.Application.Abstractions;
using Transport.Domain.Entities;
using Transport.Domain.Entities.Traine_Entities;

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
        public DbSet<OrderForAirline> ordersForAirlines { get; set; }
        public DbSet<OrderForTrain> ordersForTrains { get; set; }
        public DbSet<OrderForBus> ordersForBuses { get; set; }
        public DbSet<OrderTicketAirline> orderTicketAirlines { get; set; }
        public DbSet<OrderTicketTrain> orderTicketTrains { get; set; }
        public DbSet<PassengerForAirline> passengerForAirlines { get; set; }
        public DbSet<PassengerForTrain> passengerForTrains { get; set; }
        public DbSet<PlaceAirline> placeAirlines { get; set; }
        public DbSet<PlaceTrain> placeTrains { get; set; }
        public DbSet<TicketAirline> ticketAirlines { get; set; }
        public DbSet<TicketTrain> ticketTrains { get; set; }
        public DbSet<Train> trains { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}