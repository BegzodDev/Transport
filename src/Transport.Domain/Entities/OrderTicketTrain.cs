using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Domain.Entities.Traine_Entities
{
    public class OrderTicketTrain
    {
        public OrderTicketTrain()
        {
            PassengerForTrains = new HashSet<PassengerForTrain>();
        }
        public int? Id { get; set; }
        public int? OrederForTrainId { get; set; }

        public OrderForTrain? OrederForTrain { get; set; }
        public ICollection<PassengerForTrain>? PassengerForTrains { get; set; }
    }
}
