using Framework.Shared;
using MediatR;

namespace Framework.CQRS.Commands
{
    public interface ICommand : IRequest<Response>
    {
    }
}
