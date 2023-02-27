using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Domain.Entities
{
    public class TicketAirline
    {
        public TicketAirline()
        {
            PlaceAirlines = new HashSet<PlaceAirline>(); 
        }
        public int Id { get; set; }
        public DateTime dateTime { get; set; }


        public PassengerForAirline? passengerForAirline { get; set; }
        public ICollection<PlaceAirline>? PlaceAirlines { get; set; }
    }
}
