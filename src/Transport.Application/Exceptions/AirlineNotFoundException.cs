using Transport.Domain.Entities;

namespace Transport.Application.Exceptions
{
    public class AirlineNotFoundException : Exception
    {

        public AirlineNotFoundException()
            : base(nameof(Airline)) { }
    }
}
