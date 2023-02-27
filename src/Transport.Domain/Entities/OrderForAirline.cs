using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Domain.Entities
{
    public class OrderForAirline
    {
        public OrderForAirline()
        {
            OrderTicketAirlines = new HashSet<OrderTicketAirline>();
        }
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public double? Total_Sum { get; set; }
        public int? UserId { get; set; }

        public User? User { get; set; }
        public ICollection<OrderTicketAirline>? OrderTicketAirlines { get; set; }
    }
}
