using Microsoft.Extensions.Hosting;

namespace Transport.Application.Services
{
    public class GovernmentBackGroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public GovernmentBackGroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
