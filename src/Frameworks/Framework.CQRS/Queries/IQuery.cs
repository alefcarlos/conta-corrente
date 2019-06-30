using Framework.Shared;
using MediatR;

namespace Framework.CQRS.Queries
{
    public interface IQuery : IRequest<Response>
    {
    }
}
