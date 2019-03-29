using System;
using System.Threading;
using System.Threading.Tasks;
using Account.Domain.Services;
using Framework.Shared;

namespace Account.Application.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IAccountService _accountService;
        public BalanceService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<(ErrorResult Err, decimal Balance)> GetAccountBallanceAsync(Guid accountId, CancellationToken cancellationToken)
        {
            //Validações
            var validation = ErrorResult.Valid();

            //Obter conta do repositório
            var account = await _accountService.GetByIdAsync(accountId, cancellationToken);
            if (!account.Err.IsValid){
                return (account.Err, 0);
            }

            //Obter saldo da conta do usuário

            return (validation, 0);
        }
    }
}