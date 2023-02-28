using MediatR;
using Transport.Application.Abstractions;

namespace Transport.Application.Abstractions
{
    public interface ICommandHandler<in TRequest, TResponse> : IRequestHandler<TRequest,TResponse>
        where TRequest : ICommand<TResponse>
    {
    }
}
