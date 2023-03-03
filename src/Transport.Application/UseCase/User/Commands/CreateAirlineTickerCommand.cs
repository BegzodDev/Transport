using MediatR;
using Transport.Application.Abstractions;

namespace Transport.Application.UseCase.User.Commands
{
    public class CreateAirlineTickerCommand : ICommand<Unit>
    {
        public string? PasportSeies { get; set; }
        public DateTime? Date { get; set; }
        public string From { get; set; }
        public string For { get; set; }
    }
    public class CreateAirlineTickerCommandHandler : ICommandHandler<CreateAirlineTickerCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGovermentService _govermentService;

        public CreateAirlineTickerCommandHandler(IApplicationDbContext context, IGovermentService govermentService)
        {
            _context = context;
            _govermentService = govermentService;
        }

        public async Task<Unit> Handle(CreateAirlineTickerCommand command,CancellationToken cancellationToken)
        {
            if (!_govermentService.Check(command.PasportSeies))
            {
                throw new Exception("Pasport series is Don't have in our Base");
            }


            return Unit.Value;
        }
    }
}
