using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Application.Abstractions;

namespace Transport.Application.UseCase.User.Commands
{
    public class CreateOrderForAirlineCommand : ICommand<Unit>
    {
        public DateTime Date { get; set; }
        public string? From { get; set; }
        public string? For { get; set; }
    }
    public class CreateOrderForAirlineCommandHandler : ICommandHandler<CreateOrderForAirlineCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public CreateOrderForAirlineCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(CreateOrderForAirlineCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    
}
