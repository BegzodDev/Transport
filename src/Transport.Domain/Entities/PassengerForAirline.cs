﻿namespace Transport.Domain.Entities
{
    public class PassengerForAirline
    {

        public int? Id { get; set; }
        public string? Pasport_Series { get; set; }
        public string? SHJR { get; set; }

        public int? OrderTicketAirlineId { get; set; }
        public OrderTicketAirline? OrderTicketAirline { get; set; }
        public TicketAirline? TicketAirlines { get; set; }

    }
}
