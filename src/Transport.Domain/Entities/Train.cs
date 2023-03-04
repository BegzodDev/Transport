namespace Transport.Domain.Entities
{
    public class Train
    {
        public Train()
        {
            PlaceTrains = new HashSet<PlaceTrain>();
        }
        public int Id { get; set; }
        public string? From { get; set; }
        public string? For { get; set; }
        public double? Price { get; set; }
        public DateTime? Date { get; set; }
        public int? Count_Business_Class_Place { get; set; }
        public int? Count_Econom_Class_Place { get; set; }
        public int? Count_VIP_Class_Place { get; set; }

        public ICollection<PlaceTrain> PlaceTrains { get; set; }
    }
}
