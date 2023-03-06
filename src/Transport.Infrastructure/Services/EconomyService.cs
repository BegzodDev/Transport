using Transport.Application.Abstractions;

namespace Transport.Infrastructure.Services
{
    public class EconomyService : IEconomyService
    {
        List<string> Pasports = new List<string>()
        {
            "AB1234567",
            "AB1234561"

        };
        public bool PaymentCheck(string pasportSeries, double price)
        {
            return (Pasports.Contains(pasportSeries)) ? true : false;
        }
    }
}
