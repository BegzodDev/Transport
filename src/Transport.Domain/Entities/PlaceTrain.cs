using Transport.Domain.Enums;

namespace Transport.Domain.Entities
{
    public class PlaceTrain
    {
        public int? Id { get; set; }
        public int? Place_in_Ticket { get; set; }
        public Status Status { get; set; }

        public int? TrainId { get; set; }

        public TicketTrain? TicketTrain { get; set; }
        public Train? Train { get; set; }
    }
}
