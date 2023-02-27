﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.Domain.Entities
{
    public class OrderTicketAirline
    {
        public OrderTicketAirline()
        {
            PassengerForAirlines = new HashSet<PassengerForAirline>();
        }

        public int? Id { get; set; }
        public int? OrderForAirlineId { get; set; }

        public OrderForAirline? OrderForAirline { get; set; }
        public ICollection<PassengerForAirline>? PassengerForAirlines { get; set; }
    }
}
