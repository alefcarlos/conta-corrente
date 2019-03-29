using System;
using System.Threading.Tasks;
using Framework.Shared;

namespace Account.Domain.Services
{
    public interface IBalanceService
    {
        Task<(ErrorResult err, decimal balance)> GetAccountBallance(Guid accountId);
    }
}