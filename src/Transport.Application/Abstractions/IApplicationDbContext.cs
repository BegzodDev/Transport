using Microsoft.EntityFrameworkCore;
using Transport.Domain.Entities;

namespace Transport.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Admin> admins { get; set; }
        DbSet<User> users { get; set; }
        DbSet<Airline> airlines { get; set; }
        DbSet<Bus> bus { get; set; }
        DbSet<Train> trains { get; set; }
        DbSet<PlaceAirline> placeAirlines { get; set; }
        DbSet<PlaceTrain> placeTrains { get; set; }
        DbSet<TicketAirline> ticketAirlines { get; set; }
        DbSet<TicketTrain> ticketTrains { get; set; }
        DbSet<TicketBus> ticketBuses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
