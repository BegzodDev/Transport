using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Domain.Entities;
using Transport.Domain.Entities.Traine_Entities;

namespace Transport.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Admin> admins { get; set; }
        DbSet<User> users { get; set; }
        DbSet<Airline> airlines { get; set; }
        DbSet<Bus> bus { get; set; }
        DbSet<OrderForAirline> ordersForAirlines { get; set; }
        DbSet<OrderForTrain> ordersForTrains { get; set; }
        DbSet<OrderForBus> ordersForBuses { get; set; }
        DbSet<OrderTicketAirline> orderTicketAirlines { get; set; }
        DbSet<OrderTicketTrain> orderTicketTrains { get; set;}
        DbSet<PassengerForAirline> passengerForAirlines { get; set; }
        DbSet<PassengerForTrain> passengerForTrains { get;set; }
        DbSet<PlaceAirline> placeAirlines { get; set; }
        DbSet<PlaceTrain> placeTrains { get; set; }
        DbSet<TicketAirline> ticketAirlines { get; set; }
        DbSet<TicketTrain> ticketTrains { get; set; }
        DbSet<Train> trains { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
