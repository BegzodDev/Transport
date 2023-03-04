namespace Transport.Domain.Entities
{
    public class User
    {
        public User()
        {
            TicketAirlines= new HashSet<TicketAirline>();
            TicketTrains= new HashSet<TicketTrain>();
            TicketBuses = new HashSet<TicketBus>();
        }

        public int? Id { get; set; }
        public string? Pasport_Series { get; set; }
        public string? SHJR { get; set; }

        public ICollection<TicketBus> TicketBuses { get; set; }
        public ICollection<TicketAirline> TicketAirlines { get; set; }
        public ICollection<TicketTrain> TicketTrains { get; set; }
    }
}
