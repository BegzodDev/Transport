using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Domain.Entities.Traine_Entities
{
    public class PassengerForTrain
    {
        public int? Id { get; set; }
        public string? Pasport_Series { get; set; }
        public string? SHJR { get; set; }

        public int? OrderTicketTrainId { get; set; }
        public OrderTicketTrain? OrderTicketTrain { get; set; }
        public TicketTrain? TicketTrains { get; set; }
    }
}
