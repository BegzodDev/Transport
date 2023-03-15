using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Domain.Enums;

namespace Transport.Application.DTOs
{
    internal class TrainTicketViewModel
    {
        public int Id { get; set; }
        public int PasportSeries { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string For { get; set; }
        public int Place { get; set; }
        public Status Status { get; set; }

        public ICollection<TrainTicketViewModel> TrainTicket { get; set;}
    }
}
