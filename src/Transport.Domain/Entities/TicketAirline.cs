namespace Transport.Domain.Entities
{
    public class TicketAirline
    {

        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public string From { get; set; }
        public string For { get; set; }
        public string PasportSeries { get; set; }
        public int UserId { get; set; }
        public int PlaceAirlineId { get; set; }

        public User User { get; set; }
        public PlaceAirline PlaceAirline { get; set; }
    }
}
