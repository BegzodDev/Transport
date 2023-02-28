namespace Transport.Domain.Entities
{
    public class Bus
    {
        public int? Id { get; set; }
        public string? From { get; set; }
        public string? For { get; set; }
        public double? Price { get; set; }
        public int? OrderForBusId { get; set; }

        public OrderForBus? OrderForBus { get; set; }
    }
}
