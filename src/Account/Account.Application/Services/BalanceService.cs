using System;
using System.Threading.Tasks;
using Account.Domain.Services;
using Framework.Shared;

namespace Account.Application.Services
{
    public class BalanceService : IBalanceService
    {
        public  async Task<(ErrorResult err,  decimal balance)> GetAccountBallance(Guid accountId)
        {
            //Validações

            return (ErrorResult.Valid(), 0);
        }
    }
}