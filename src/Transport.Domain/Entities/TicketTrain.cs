using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Domain.Entities.Traine_Entities;

namespace Transport.Domain.Entities
{
    public class TicketTrain
    {
        public TicketTrain()
        {
            PlaceTrains = new HashSet<PlaceTrain>(); 
        }
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public int? PassergerForTrainId { get; set; }

        public PassengerForTrain? PassergerForTrain { get; set; }
        public ICollection<PlaceTrain>? PlaceTrains { get; set; }
    }
}
