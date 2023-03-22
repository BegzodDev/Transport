using Transport.Domain.Enums;

namespace Transport.Application.DTOs
{
    public class TicketAirlineViewModel
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public int? PassergerForTrainId { get; set; }

        public int UserId { get; set; }
        public int PlaceTrainId { get; set; }
        public ICollection<TicketAirlineViewModel> TicketAirline { get; set; }
    }
}
