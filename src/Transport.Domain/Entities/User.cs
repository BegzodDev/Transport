namespace Transport.Domain.Entities
{
    public class User
    {
        public User()
        {
            TicketAirlines = new HashSet<TicketAirline>();
            TicketTrains = new HashSet<TicketTrain>();
            TicketBuses = new HashSet<TicketBus>();
        }

        public int? Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<TicketBus> TicketBuses { get; set; }
        public ICollection<TicketAirline> TicketAirlines { get; set; }
        public ICollection<TicketTrain> TicketTrains { get; set; }
    }
}
