using System.Threading;
using System.Threading.Tasks;
using Account.Application.Data.Repositories;
using Account.Application.Queries;
using Framework.Shared;
using MediatR;

namespace Account.Application.Handlers.Queries
{
    public class TransactionQueryHandler :
     IRequestHandler<TransactionsByAccount, Response>
    {

        public TransactionQueryHandler(ITransactionRepository repo)
        {
            this.repo = repo;
        }

        private ITransactionRepository repo;

        public async Task<Response> Handle(TransactionsByAccount queryParameters, CancellationToken cancellationToken)
        {
            var result = await repo.ReadAsync(tr => tr.AccountId == queryParameters.ID);

            return new Response(result);

        }
    }
}