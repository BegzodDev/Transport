using Transport.Domain.Entities.Traine_Entities;

namespace Transport.Domain.Entities
{
    public class OrderForTrain
    {
        public OrderForTrain()
        {
            OrderTicketTrains = new HashSet<OrderTicketTrain>();
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Total_Sum { get; set; }
        public int? UserId { get; set; }

        public User? User { get; set; }
        public ICollection<OrderTicketTrain>? OrderTicketTrains { get; set; }
    }
}
