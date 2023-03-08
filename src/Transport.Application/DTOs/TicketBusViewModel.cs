using Transport.Domain.Entities;

namespace Transport.Application.DTOs
{
    public class TicketBusViewModel
    {
        public string? PasportSeries { get; set; }
        public DateTime? Date { get; set; }
        public string From { get; set; }
        public string For { get; set; }
    }
}
