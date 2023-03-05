namespace Transport.Application.DTOs
{
    public class AirLineViewModel
    {
        public string? Flight_From { get; set; }
        public string? Flight_For { get; set; }
        public double? Price { get; set; }
        public DateTime Date { get; set; }
        public int? Count_Business_Class_Place { get; set; }
        public int? Count_Econom_Class_Place { get; set; }
        public int? Count_VIP_Class_Place { get; set; }

    }
}
