using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Domain.Enums;

namespace Transport.Application.DTOs
{
    public interface TicketAirlineViewModel
    {
        
        public string? PasportSeies { get; set; }
        public DateTime? Date { get; set; }
        public string From { get; set; }
        public string For { get; set; }
        public int Place { get; set; }
        public Status Status { get; set; }

    }
}
