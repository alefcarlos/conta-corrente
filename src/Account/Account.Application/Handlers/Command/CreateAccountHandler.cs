using Account.Application.Commands;
using Account.Domain.Data.Repositories;
using Account.Domain.Entities;
using Framework.CQRS;
using Framework.CQRS.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Application.Handlers.Command
{

    public class CreateAccountHandler : IRequestHandler<CreateAccount, Response>
    {
        private readonly IAccountRepository _accountRepository;
        public CreateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Response> Handle(CreateAccount request, CancellationToken cancellationToken)
        {
            var result = await _accountRepository.CreateAsync(new AccountEntity(request.Name, request.CPF));

            return Response.Ok(result.AccountId);
        }
    }
}
