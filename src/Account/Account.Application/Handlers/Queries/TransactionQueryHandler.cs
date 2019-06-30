using System.Threading;
using System.Threading.Tasks;
using Account.Application.Queries;
using Framework.Shared;
using MediatR;

namespace Account.Application.Handlers.Queries
{
    public class TransactionQueryHandler :
     IRequestHandler<TransactionsByAccount, Response>
    {
        public Task<Response> Handle(TransactionsByAccount request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}