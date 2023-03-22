using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Domain.Enums;

namespace Transport.Application.DTOs
{
    public class TrainTicketViewModel
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public int? PassergerForTrainId { get; set; }

        public int UserId { get; set; }
        public int PlaceTrainId { get; set; }


        public ICollection<TrainTicketViewModel> TicketTrain { get; set; }
    }
}
