using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Domain.Entities
{
    public class Bus
    {
        public int? Id { get; set; }
        public string? From { get; set; }
        public string? For { get; set; }
        public double? Price { get; set; }
        public int? UserId { get; set; }

        public User? User { get; set; }
    }
}
