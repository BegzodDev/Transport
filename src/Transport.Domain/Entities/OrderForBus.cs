using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Domain.Entities
{
    public class OrderForBus
    {
        public OrderForBus()
        {
            Buses = new HashSet<Bus>();
        }
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public double? Total_Sum { get; set; }
        public int? UserId { get; set; }

        public User? User { get; set; }
        public ICollection<Bus> Buses { get; set; }
    }
}
