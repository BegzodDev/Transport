namespace Transport.Application.DTOs
{
    public class AirLineViewModel
    {
        public string FlightFrom { get; set; } = string.Empty;
        public string FlightTo { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public int CountBusinessClassPlace { get; set; }
        public int CountEconomyClassPlace { get; set; }
        public int CountVIPClassPlace { get; set; }
    }
}
