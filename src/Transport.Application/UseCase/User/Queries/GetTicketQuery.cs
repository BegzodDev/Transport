using MediatR;
using Transport.Application.Abstractions;
using Transport.Application.DTOs;

namespace Transport.Application.UseCase.User.Queries
{
    public class GetTicketQuery : ICommand<TicketAirlineViewModel>
    {
    }
}
