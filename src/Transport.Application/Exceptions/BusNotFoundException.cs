using Transport.Domain.Entities;

namespace Transport.Application.Exceptions
{
    public class BusNotFoundException : Exception
    {
        public BusNotFoundException()
            : base(nameof(Bus)) { }
    }
}
