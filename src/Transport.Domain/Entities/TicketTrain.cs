namespace Transport.Domain.Entities
{
    public class TicketTrain
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public int? PassergerForTrainId { get; set; }


        public int UserId { get; set; }
        public int PlaceTrainId { get; set; }
        public User? User { get; set; }
        public PlaceTrain? PlaceTrains { get; set; }
    }
}
