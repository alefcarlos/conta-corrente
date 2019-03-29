using System;
using System.Threading;
using System.Threading.Tasks;
using Account.Domain.Services;
using Framework.Shared;

namespace Account.Application.Services
{
    public class BalanceService : IBalanceService
    {
        public async Task<(ErrorResult Err, decimal Balance)> GetAccountBallanceAsync(Guid accountId, CancellationToken cancellationToken)
        {
            //Validações
            var validation = ErrorResult.Valid();

            //Obter conta do repositório
            
            return (validation, 0);
        }
    }
}