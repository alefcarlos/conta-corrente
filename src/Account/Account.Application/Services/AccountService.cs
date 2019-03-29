using System;
using System.Threading;
using System.Threading.Tasks;
using Account.Domain.Entities;
using Account.Domain.Services;
using Framework.Shared;

namespace Account.Application.Services
{
    public class AccountService : IAccountService
    {
        public async Task<(ErrorResult Err, AccountEntity Entity)> GetByIdAsync(Guid accountId, CancellationToken cancellationToken)
        {
            var validation = ErrorResult.Valid();

            //Obter registro do repositório

            return (validation, new AccountEntity() { Name = "Alef" });
        }
    }
}