namespace Transport.Domain.Entities
{
    public class User
    {
        public User()
        {
            OrderForAirlines = new HashSet<OrderForAirline>();
            OrderForTrains = new HashSet<OrderForTrain>();
            OrderForBuses = new HashSet<OrderForBus>();
        }

        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }

        public ICollection<OrderForBus> OrderForBuses { get; set; }
        public ICollection<OrderForTrain> OrderForTrains { get; set; }
        public ICollection<OrderForAirline> OrderForAirlines { get; set; }
    }
}
