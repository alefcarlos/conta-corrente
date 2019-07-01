using Account.Application.Commands;
using Account.Application.Data.Repositories;
using Account.Domain.Entities;
using Framework.Shared;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Application.Handlers.Commands
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
            var entity = await _accountRepository.CreateAsync(new AccountEntity(request.Name, request.CPF));

            return new Response(entity);
        }
    }
}
