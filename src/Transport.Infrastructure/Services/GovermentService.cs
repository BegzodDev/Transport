using Transport.Application.Abstractions;

namespace Transport.Infrastructure.Services
{
    public class GovermentService : IGovermentService
    {
        List<string> Pasport_Series = new List<string>()
        {
            "AB1234567",
            "AB1234561",
            "AB1234562"
        };
        public bool Check(string pasportSeries)
        {
            return Pasport_Series.Contains(pasportSeries) ? true : false;
        }
    }
}
