using Transport.Domain.Enums;

namespace Transport.Domain.Entities
{
    public class PlaceAirline
    {
        public int? Id { get; set; }
        public int? Place_in_Ticket { get; set; }
        public Status Status { get; set; }

        public int? AirlineId { get; set; }
        public int? TicketAirlineId { get; set; }

        public TicketAirline? TicketAirline { get; set; }
        public Airline? Airline { get; set; }
    }
}
