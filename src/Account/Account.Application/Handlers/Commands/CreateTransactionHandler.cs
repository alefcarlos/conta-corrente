using Account.Application.Commands;
using Account.Application.Data.Repositories;
using Account.Domain.Entities;
using Framework.Shared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Application.Handlers.Commands
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransaction, Response>
    {
        private readonly ITransactionRepository _repository;

        public CreateTransactionHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(CreateTransaction request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TransactionEntity(request.AccountId, request.Value, request.Type, request.Date));

            return new Response();
        }
    }
}
