﻿using Transport.Domain.Enums;

namespace Transport.Application.DTOs
{
    public interface TicketAirlineViewModel
    {
        public int? Id { get; set; }

        public int Place { get; set; }
        public Status Status { get; set; }

        public ICollection<TicketAirlineViewModel> TicketAirline { get; set; }
    }
}
