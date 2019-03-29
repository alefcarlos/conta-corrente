using System;
using System.Threading;
using System.Threading.Tasks;
using Framework.Shared;

namespace Account.Domain.Services
{
    public interface IBalanceService
    {
        Task<(ErrorResult Err, decimal Balance)> GetAccountBallanceAsync(Guid accountId, CancellationToken cancellationToken);
    }
}