using Account.Application.Data.Repositories;
using Account.Application.Queries;
using Account.Domain.Entities;
using Framework.Shared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Application.Handlers.Queries
{
    public class AccountQueryHandler : IRequestHandler<AccountByIdentifier, Response>
    {

        private readonly IAccountRepository _accountRepository;
        public AccountQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Response> Handle(AccountByIdentifier queryParameters, CancellationToken cancellationToken)
        {
            var response = new Response();
            AccountEntity entity;

            if (queryParameters.IsDocument)
                entity = await _accountRepository.ReadFirstOrDefaultAsync(x => x.CPF == queryParameters.Document);
            else
                entity = await _accountRepository.ReadFirstOrDefaultAsync(x => x.AccountId == queryParameters.Id);


            if (entity == null)
                response.AddNotification("Conta", "Conta não encontrada.");
            else
                response.SetResult(entity);

            return response;
        }
    }
}
