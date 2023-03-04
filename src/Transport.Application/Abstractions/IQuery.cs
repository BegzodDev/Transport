using MediatR;

namespace Transport.Application.Abstractions
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
