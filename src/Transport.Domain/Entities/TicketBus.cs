namespace Transport.Domain.Entities
{
    public class TicketBus
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Sum { get; set; }
        public string For { get; set; }
        public string From { get; set; }
        public string PassportSeria { get; set; }

        public int? UserId { get; set; }
        public int? BusId { get; set; }
        public User? User { get; set; }
        public Bus? Bus { get; set; }
    }
}
