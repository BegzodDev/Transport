namespace Transport.Application.Abstractions
{
    public interface IEconomyService
    {
        public bool PaymentCheck(string pasportSeries, double price);

    }
}
