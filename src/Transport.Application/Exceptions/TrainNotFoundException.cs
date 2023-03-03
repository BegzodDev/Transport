using Transport.Domain.Entities;

namespace Transport.Application.Exceptions
{
    public class TrainNotFoundException : Exception
    {
        public TrainNotFoundException()
           : base(nameof(Bus)) { }
    }
}
